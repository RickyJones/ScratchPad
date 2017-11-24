package md5826fb2b18a4bc40553beb81ff0fb3b9b;


public abstract class BaseElementActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_setContentView:(Landroid/view/View;)V:GetSetContentView_Landroid_view_View_Handler\n" +
			"";
		mono.android.Runtime.register ("ScratchApp.Activities.BaseElementActivity, ScratchApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", BaseElementActivity.class, __md_methods);
	}


	public BaseElementActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == BaseElementActivity.class)
			mono.android.TypeManager.Activate ("ScratchApp.Activities.BaseElementActivity, ScratchApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void setContentView (android.view.View p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (android.view.View p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
