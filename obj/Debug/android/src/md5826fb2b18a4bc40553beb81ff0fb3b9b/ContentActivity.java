package md5826fb2b18a4bc40553beb81ff0fb3b9b;


public class ContentActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ScratchApp.Activities.ContentActivity, ScratchApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ContentActivity.class, __md_methods);
	}


	public ContentActivity ()
	{
		super ();
		if (getClass () == ContentActivity.class)
			mono.android.TypeManager.Activate ("ScratchApp.Activities.ContentActivity, ScratchApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
