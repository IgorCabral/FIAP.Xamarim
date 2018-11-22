package md56cc2b36e9dbc9f5c836f0845990a4e71;


public class FiapBoxViewRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.BoxRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("XF.Recursos.Droid.Custom.FiapBoxViewRenderer, XF.Recursos.Android", FiapBoxViewRenderer.class, __md_methods);
	}


	public FiapBoxViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == FiapBoxViewRenderer.class)
			mono.android.TypeManager.Activate ("XF.Recursos.Droid.Custom.FiapBoxViewRenderer, XF.Recursos.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public FiapBoxViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == FiapBoxViewRenderer.class)
			mono.android.TypeManager.Activate ("XF.Recursos.Droid.Custom.FiapBoxViewRenderer, XF.Recursos.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public FiapBoxViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == FiapBoxViewRenderer.class)
			mono.android.TypeManager.Activate ("XF.Recursos.Droid.Custom.FiapBoxViewRenderer, XF.Recursos.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);

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
