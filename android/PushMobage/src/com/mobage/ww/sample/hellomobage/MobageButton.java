package com.mobage.ww.sample.hellomobage;

import java.io.IOException;
import java.io.InputStream;

import com.mobage.global.android.lang.DismissableAPIStatus;
import com.mobage.global.android.lang.Error;
import com.mobage.global.android.social.common.Service;
import com.mobage.global.android.social.common.Service.IShowCommunityUICallback;

import android.app.Activity;
import android.content.Context;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.StateListDrawable;
import android.util.Log;
import android.view.Display;
import android.view.View;
import android.view.WindowManager;
import android.widget.ImageButton;
import android.widget.RelativeLayout;

public class MobageButton extends ImageButton {
	
	private String TAG = "MobageButton";
	
	private StateListDrawable stateList;

	public MobageButton(final Context context) {
		super(context);
		
		// get the appropriate mobage button size
		WindowManager wm = (WindowManager) context.getSystemService(Context.WINDOW_SERVICE);
		Display display = wm.getDefaultDisplay();
		int width  = display.getWidth();
		int height = display.getHeight();
		
		int buttonSize = 64;
		if (width > height) {
			buttonSize = (int) ((float)height * 0.11875);
		} else {
			buttonSize = (int) ((float)width * 0.11875);
		}
		
		int[] controlState;
		
		stateList = new StateListDrawable();
		
		try {
			// normal state
			controlState = new int[]{ android.R.attr.state_enabled , -android.R.attr.state_pressed};
			stateList.addState(controlState, getMobageButtonIconForSize(buttonSize, "top-left.png"));
			
			// pressed state
			controlState = new int[]{ android.R.attr.state_pressed};
			stateList.addState(controlState, getMobageButtonIconForSize(buttonSize, "top-left-down.png"));
			
			setBackgroundDrawable(stateList);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		RelativeLayout.LayoutParams params = new RelativeLayout.LayoutParams(buttonSize, buttonSize);
		params.addRule(RelativeLayout.ALIGN_PARENT_TOP);
		params.addRule(RelativeLayout.ALIGN_PARENT_LEFT);
	    this.setLayoutParams(params);

		// set onclick listener
		setOnClickListener(new OnClickListener() {
			public void onClick(View view) {
				Service.showCommunityUI(
						(Activity) context, new IShowCommunityUICallback() {
							public void onComplete(DismissableAPIStatus status,
									Error error) {
								switch (status) {
								case dismiss:
								case success:
									Log.v(TAG, "Dismissed");
									break;
								case error:
									Log.v(TAG,
											"Community UI error: "
													+ error.getDescription());
									break;
								}
							}
						});
			}
		});
	}
	
	private Drawable getMobageButtonIconForSize(int size, String imageName) throws IOException {
		String resPath = "CommunityBtn-64-LowRez/";
		if (size > 64) {
			resPath = "CommunityBtn-128-MedRez/";
		}
		if (size > 128) {
			resPath = "CommunityBtn-192-HiRez/";
		}

		InputStream is = getContext().getResources().getAssets().open("MobageResources/" + resPath + imageName);
		BitmapDrawable bitmapDrawable = new BitmapDrawable(BitmapFactory.decodeStream(is));
		
		return bitmapDrawable;
	}

}
