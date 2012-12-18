var Color = require('NGCore/Client/Core/Color').Color;
var GLView = require('NGCore/Client/UI/GLView').GLView;
var LayoutEmitter = require('NGCore/Client/Device/LayoutEmitter').LayoutEmitter;
var Point = require('NGCore/Client/Core/Point').Point;
var Root = require('NGCore/Client/GL2/Root').Root;
var Size = require('NGCore/Client/Core/Size').Size;
var Text = require('NGCore/Client/GL2/Text').Text;
var Social = require('NGCore/Client/Social').Social;
var UI = require('NGCore/Client/UI').UI;

function main() {
  var glView = new GLView();
  glView.setFrame(0, 0, LayoutEmitter.getWidth(), LayoutEmitter.getHeight());
  
  function onLoad() {
    displayHelloWorld();
    
    addRemoteNotificationListener();
    
    checkIfRemoteNotificationsAreEnabled();
    
    getPendingRemoteNotification();
    
    sendRemoteNotificationToSelf();
  }
 
  glView.setOnLoad(onLoad);
  glView.setActive(true);
}  

function addRemoteNotificationListener() {
  Device.NotificationEmitter.addListener(new Core.MessageListener(), function(notification) {
    if (notification.type == Device.NotificationEmitter.Type.Remote) {
       console.log("Received remote notification: " + JSON.stringify(notification));
    } else {
       console.log("Non-remote type: " + notification.type);
    }
  });
}

function getPendingRemoteNotification() {
  var notification = Device.NotificationEmitter.getPendingNotification();
  if (notification) {
    console.log("Got pending remote notification: " + JSON.stringify(notification));
  } else {
    console.log("There was no pending remote notification.");
  }
}

function checkIfRemoteNotificationsAreEnabled() {
  Social.Common.RemoteNotification.getRemoteNotificationsEnabled(function(error, canBeNotified) {
    if (error) {
      console.log("Error checking if remote notificaitons are enabled: " + error.errorCode);
    } else {
      if (canBeNotified) {
        console.log("The current user can receive remote notifications.");
      } else {
        // optionally call setRemoteNotificationsEnabled()
        console.log("The current user can not receive remote notifications.");
      }
    }
  });
}

function sendRemoteNotificationToSelf() {
  Social.Common.People.getCurrentUser(["id"], function(error, user) {
    if (error) {
      console.log("Error getting current user: " + error.errorCode);
    } else {
      var payload = {
        message: "Come join my quest!"
      };
      Social.Common.RemoteNotification.send(user.id, payload, function(error, remoteNotification) {
        if (error) {
          console.log("Error sending remote notification: " + error.errorCode);
        } else {
          console.log("Queued remote notification with ID " + remoteNotification.id);
        }
      });
    }
  });
}

function displayHelloWorld() {
  var size = new Size(LayoutEmitter.getWidth(), LayoutEmitter.getHeight());
 
  var color = new Color(0, 0.29, 0.64);
  var fontSize = Math.round(size.getWidth() / 10);
  var position = new Point(size.getWidth() / 2, size.getHeight() / 2);
 
  var helloWorld = new Text().setText('Hello World').setColor(color).setFontSize(fontSize).setPosition(position);
 
  Root.addChild(helloWorld);
}