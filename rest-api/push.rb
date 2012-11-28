#!/usr/bin/env ruby

begin
  require 'rubygems'
  require 'thor'
  require 'net/https'
  require 'uri'
  require 'simple_oauth'
  require 'yaml'
  require 'json'
rescue LoadError
  puts "Please install the gem: #{$!.message.split(' ').last}"
  exit
end

begin
  $credentials = YAML::load(File.open(File.join(File.dirname(__FILE__),'credentials.yml')))
rescue
  puts "Please copy credentials.yml.template to credentials.yml and fill in with your master app's values"
  exit
end

$app_id = $credentials.delete(:app_id)
$server = "https://app-sandbox.mobage.com"

$uri = URI.parse($server)
$http = Net::HTTP.new($uri.host, $uri.port)
$http.use_ssl = true

class Push < Thor
  map "b" => :broadcast, "u" => :user
  
  def self.set_common_options
    method_option :debug, :aliases => ["-d"], :banner => "true", :type => :boolean, :desc => "Turn on net/http debug output"
    method_option :dry_run, :banner => "true", :type => :boolean, :desc => "When set, no HTTP request is actually made"
    method_option :extras, :type => :hash, :banner => "key1:value1 key2:value2", :desc => "Extras to send with the push notification"
  end
  
  desc 'broadcast "message" [-d] [--dry_run=true] [--extras=key:value [key:value ...]]', "Send 'message' to all users of your app"
  set_common_options
  def broadcast(message)
    puts "Sending broadcast message: #{message}"
    path = "/1/#{$app_id}/opensocial/remote_notification/@app/@all"
    send_remote_notification(path, message, options)
  end
  
  desc 'user <user> "message" [-d] [--from=sender_id] [--extras=key:value [key:value ...]]', "Send 'message' to <user>, specifying an id or a username"
  set_common_options
  method_option :from, :banner => "sender_id", :desc => "The id of the sender"
  def user(user_id, message)
    puts "Sending message to #{user_id}: #{message}"
    path = "/1/#{$app_id}/opensocial/remote_notification/@app/@all/#{user_id}"
    send_remote_notification(path, message, options)
  end
  
private
  def send_remote_notification(path, message, options={})
    $http.set_debug_output($stdout) if options.debug?
    
    method = "POST"
    url = "#{$server}#{path}"
    
    payload = { "message" => message }
    payload["extras"] = options[:extras] if options[:extras]
    payload["sender_id"] = options[:from] if options[:from]
    
    if options.debug?
      puts "Payload:"
      puts payload.to_json
    end
    
    params = { "payload" => payload.to_json }
        
    oauth_header = SimpleOAuth::Header.new(method, url, params, $credentials)
    
    request = Net::HTTP::Post.new(path)
    request.body = %|payload=#{URI.encode(params["payload"])}|
    request['Authorization'] = oauth_header.to_s
    request['Accept'] = 'application/json'
    request['Content-Type'] = 'application/x-www-form-urlencoded'
    
    if options.dry_run?
      puts "Dry run -- nothing sent!"
    else
      response = $http.request(request)
      puts "Response code: #{response.code}"
      puts "Response body: #{response.body}"
    end
  end
end

Push.start