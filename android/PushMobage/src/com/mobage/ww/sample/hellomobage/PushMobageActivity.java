package com.mobage.ww.sample.hellomobage;

import android.os.Bundle;
import android.app.Activity;
import android.content.Intent;
import android.content.res.Resources;
import android.view.Menu;
import android.util.Log;
import android.widget.Toast;

import com.mobage.android.analytics.IAnalyticsActivity;
import com.mobage.android.analytics.IEventReporter.EventReportException;

import com.mobage.global.android.Mobage;
import com.mobage.global.android.ServerMode;
import com.mobage.global.android.social.util.InvalidParameterException;
import com.mobage.global.android.data.RemoteNotificationResponse;
import com.mobage.global.android.data.User;
import com.mobage.global.android.lang.CancelableAPIStatus;
import com.mobage.global.android.lang.Error;
import com.mobage.global.android.lang.SimpleAPIStatus;
import com.mobage.global.android.social.common.RemoteNotification;
import com.mobage.global.android.data.RemoteNotificationPayload;
import com.mobage.global.android.social.common.Service;
import com.mobage.global.android.social.common.Service.IExecuteLoginCallback;
import com.mobage.global.android.social.common.People;

import com.mobage.ww.sample.hellomobage.R;

public class PushMobageActivity extends Activity {
	protected String TAG = "PushMobageActivity";
	
	IAnalyticsActivity analyticsReporter = null;
	
	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		// First we're going to detect if the app was launched by a remote notification.
		// If so, we'll inspect the entries
		if (getIntent() != null && getIntent().getExtras() != null && getIntent().getExtras().size() > 0) {
			Log.d(TAG, "Received extras in onCreate()");
			Bundle extras = getIntent().getExtras();
			for (String key : extras.keySet()) {
				Log.d(TAG, "Extra '" + key + "': '" + extras.getString(key) + "'");
			}
		}
		
		// If we're not the task root, we're going to exit now.
		// This can happen if the user taps on a remote notification while the Mobage Community UI is the top-most activity.
		if (!this.isTaskRoot()) {
			Log.d(TAG, "Activity is not root task. Finishing.");
			this.finish();
		}
		
		// Now we'll continue with our normal setup
		
		setContentView(R.layout.main);

		try {
			Mobage mobage = Mobage.getInstance();
			Resources resources = getResources();
			mobage.initialize(this, ServerMode.SANDBOX, resources.getString(R.string.appId), "1.0", resources.getString(R.string.consumerKey), resources.getString(R.string.consumerSecret));
		} catch (EventReportException e) {
			Log.e(TAG, e.getMessage(), e);
		} catch (InvalidParameterException e) {
			Log.e(TAG, e.getMessage(), e);
		}
		
	    analyticsReporter = Mobage.getInstance().newAnalyticsActivity(getComponentName().flattenToString());
		
	    Service.executeLogin(this, new IExecuteLoginCallback() {
			public void onComplete(CancelableAPIStatus status, Error error) {
				switch (status) {
				case cancel:
					Log.i(TAG, "User cancelled login");
					break;
				case error:
					Log.i(TAG, "The login process had an error " + error.getDescription());
					break;
				case success:
					Log.i(TAG, "User login successful");

					// Now that we're logged in, we're going to sign up for remote notifications
					RemoteNotification.setRemoteNotificationsEnabled(true, new RemoteNotification.ISetRemoteNotificationsEnabledCallback() {
						public void onComplete(SimpleAPIStatus status, Error error) {
							switch (status) {
							case error:
								Log.i(TAG, "The setRemoteNotificationsEnabled call experienced the error: " + error.getDescription());
								break;
							case success:
								Log.i(TAG, "User successfully registered for remote notifications!");
								break;
							}
						}
					});

					// We're going to get the current user so that we know we have a valid username who can receive remote notifications
					People.getCurrentUser(new People.IGetCurrentUserCallback() {
						public void onComplete(SimpleAPIStatus status, Error error, User user) {
							switch (status) {
							case error:
								Log.i(TAG, "The getCurrentUserCall experienced an error " + error.getDescription());
								break;
							case success:
								Toast toast = Toast.makeText(getApplicationContext(), user.getNickname() + ", welcome to Mobage", Toast.LENGTH_LONG);
								toast.show();

								// First we create a payload to hold our notification information
								RemoteNotificationPayload payload = new RemoteNotificationPayload();
								payload.setMessage("Remote notification from Android!");
								
								// We can optionally include extra information
								payload.putExtra("key1", "value1");
								payload.putExtra("key2", "value2");
								
								// Now we ask Mobage to deliver it for us
								RemoteNotification.send(user.getNickname(), payload, new RemoteNotification.ISendCallback() {
									public void onComplete(SimpleAPIStatus status, Error error, RemoteNotificationResponse response) {
										switch (status) {
										case error:
											Log.i(TAG, "The RemoteNotification#send call experienced an error: " + error.getDescription());
											break;
										case success:
											Log.i(TAG, "Successfully sent remote notification.");
											break;
										}
									}
								}); // RemoteNotification.send
								break;
							}
						}
					}); // People.getCurrentUser
					break;
				}
			}
		}); // Service.executeLogin
	    
	    // Let's double check to make sure our notifications are enabled. They may not be the first time this is run due to
	    // network delays, but subsequent runs should show that they're enabled.
		RemoteNotification.getRemoteNotificationsEnabled(new RemoteNotification.IGetRemoteNotificationsEnabledCallback() {
			public void onComplete(SimpleAPIStatus status, Error error, boolean enabled) {
				switch(status) {
				case success:
					Log.i(TAG, "Remote Notification enabled? " + enabled);
					break;
				case error:
					Log.i(TAG, "Error in getRemoteNotificationsEnabled: " + error.getDescription());
					break;
				} 
			}
		});
	}
	
	@Override
	protected void onNewIntent(Intent intent) {
		super.onNewIntent(intent);
		Log.i(TAG, "onNewIntent() called.");
		if (intent != null && intent.getExtras() != null && intent.getExtras().size() > 0) {
			Log.d(TAG, "Received extras in onNewIntent()");
			Bundle extras = intent.getExtras();
			for (String key : extras.keySet()) {
				Log.d(TAG, "Extra '" + key + "': '" + extras.getString(key) + "'");
			}
		}
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public void onPause() {
		super.onPause();
		if (Mobage.isInitialized()) {
			Mobage.getInstance().onPause();
			if (analyticsReporter != null)
				analyticsReporter.onPause();
		}
	}

	@Override
	public void onResume() {
		super.onResume();
		if (Mobage.isInitialized()) {
			Mobage.getInstance().onResume();
			if (analyticsReporter != null)
				analyticsReporter.onResume();
		}
	}

	@Override
	public void onStart() {
		super.onStart();
		if (analyticsReporter != null)
			analyticsReporter.onStart();
	}

	@Override
	public void onStop() {
		super.onStop();
		if (Mobage.isInitialized()) {
			Mobage.getInstance().onStop();
			if (analyticsReporter != null)
				analyticsReporter.onStop();
		}
	}

	@Override
	protected void onRestart() {
		super.onRestart();
		if (Mobage.isInitialized())
			Mobage.getInstance().onRestart();
	}

	@Override
	protected void onDestroy() {
		super.onDestroy();
		if (Mobage.isInitialized())
			Mobage.getInstance().onDestroy();
	}
}
