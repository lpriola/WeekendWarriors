package com.WeekendWarriors.Pinball;

import android.animation.ValueAnimator;
import android.app.Activity;
import android.content.Intent;
import android.media.MediaPlayer;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.view.animation.LinearInterpolator;
import android.widget.Button;
import android.widget.ImageView;

public class Main extends Activity {

    private MediaPlayer mp;
    private MediaPlayer mp2;

    double myRandom = 0;
    double myRandom2 = 0;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.mainmenu);
        Button startButton = findViewById(R.id.startButton);
        final ImageView test1 = findViewById(R.id.pinballMachine);

        /* Triggers "Immersive mode" to hide bottom UI bar. Does not pass to other activities.
         * Will only work on KitKat and above */
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.KITKAT) {
            int UI_OPTIONS = View.SYSTEM_UI_FLAG_HIDE_NAVIGATION | View.SYSTEM_UI_FLAG_FULLSCREEN | View.SYSTEM_UI_FLAG_LAYOUT_STABLE | View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY | View.SYSTEM_UI_FLAG_LAYOUT_HIDE_NAVIGATION;
            getWindow().getDecorView().setSystemUiVisibility(UI_OPTIONS);
        }

        /* Media Player to handle the pinball sounds on title screen */
        mp = MediaPlayer.create(Main.this, R.raw.pinball_sfx);
        mp2 = MediaPlayer.create(Main.this, R.raw.title_music);
        mp2.start();
        mp2.setLooping(true);
        mp.start();
        mp.setLooping(true);

        /* Webview wv contains the pinball gif animation. Imageviews do not animate*/
        // WebView wv = findViewById(R.id.pinballview);
        // wv.loadUrl("file:///android_asset/pinball.gif");
        //wv.setBackgroundColor(0);
        //wv.setLayerType(WebView.LAYER_TYPE_SOFTWARE, null);

        myRandom = genRandom(myRandom);
        myRandom2 = genRandom(myRandom2);

        final ValueAnimator pinballAnimator = ValueAnimator.ofFloat(0.0f, 1.0f);
        final ValueAnimator pinballAnimator2 = ValueAnimator.ofFloat(5.0f, 5.0f);
        final ValueAnimator pinballAnimator3 = ValueAnimator.ofFloat(0.0f, -1.5f);
        final ValueAnimator pinballAnimator4 = ValueAnimator.ofFloat(0.0f, 3.0f);

        pinballAnimator.setRepeatCount(ValueAnimator.INFINITE);
        pinballAnimator.setInterpolator(new LinearInterpolator());
        pinballAnimator.setDuration(10000L);
        pinballAnimator.addUpdateListener(new ValueAnimator.AnimatorUpdateListener() {
            @Override
            public void onAnimationUpdate(ValueAnimator valueAnimator) {
                final float progress = (float) pinballAnimator.getAnimatedValue();
                final float width = test1.getWidth() * 5;
                final float translationX = width * progress;
                final float translationY = width * progress;
                test1.setTranslationX(translationX + 3);
                test1.setTranslationY(translationY + 2);

            }
        });

        pinballAnimator.start();

        pinballAnimator2.setRepeatCount(ValueAnimator.INFINITE);
        pinballAnimator2.setInterpolator(new LinearInterpolator());
        pinballAnimator2.setDuration(10000L);
        pinballAnimator2.addUpdateListener(new ValueAnimator.AnimatorUpdateListener() {
            @Override
            public void onAnimationUpdate(ValueAnimator valueAnimator) {
                final float progress = (float) pinballAnimator2.getAnimatedValue();
                final float width = test1.getWidth() * 5;
                final float translationX = width * progress;
                final float translationY = width * progress;

            }
        });

        pinballAnimator2.start();


        /* Scrolling background elements
         * Requires 2 backgrounds to work properly without a seam in between */
        final ImageView backgroundOne = findViewById(R.id.scrollingbg1);
        final ImageView backgroundTwo = findViewById(R.id.scrollingbg2);
        final ValueAnimator animator = ValueAnimator.ofFloat(0.3f, 1.0f);
        animator.setRepeatCount(ValueAnimator.INFINITE);
        animator.setInterpolator(new LinearInterpolator());
        animator.setDuration(10000L);
        animator.addUpdateListener(new ValueAnimator.AnimatorUpdateListener() {
            @Override
            public void onAnimationUpdate(ValueAnimator animation) {
                final float progress = (float) animation.getAnimatedValue();
                final float width = backgroundOne.getWidth() -80;
                final float translationX = width * progress;
                backgroundOne.setTranslationX(translationX);
                backgroundTwo.setTranslationX(translationX - width);


            }
        });
        pinballAnimator4.start();
        animator.start();
        /* Button to start DemoMenu Activity. No values are passed along*/
        startButton.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                Intent intent = new Intent(getApplicationContext(), UnityPlayerActivity.class);
                mp.stop();
                mp2.stop();
                startActivity(intent);

            }
        });
    }

    public static double genRandom(double x)
    {
        x = (Math.random()*((95-5)+1))+5;
        return x;
    }
}
