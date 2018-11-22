package md56cc2b36e9dbc9f5c836f0845990a4e71;


public class FiapButtonRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.ButtonRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("XF.Recursos.Droid.Custom.FiapButtonRenderer, XF.Recursos.Android", FiapButtonRenderer.class, __md_methods);
	}


	public FiapButtonRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == FiapButtonRenderer.class)
			mono.android.TypeManager.Activate ("XF.Recursos.Droid.Custom.FiapButtonRenderer, XF.Recursos.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public FiapButtonRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == FiapButtonRenderer.class)
			mono.android.TypeManager.Activate ("XF.Recursos.Droid.Custom.FiapButtonRenderer, XF.Recursos.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public FiapButtonRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == FiapButtonRenderer.class)
			mono.android.TypeManager.Activate ("XF.Recursos.Droid.Custom.FiapButtonRenderer, XF.Recursos.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}

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
