package crc6450eb4ad7d396ddb2;


public class BorderViewRenderer
	extends crc643f46942d9dd1fff9.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dispatchDraw:(Landroid/graphics/Canvas;)V:GetDispatchDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("XamEffects.Droid.Renderers.BorderViewRenderer, XamEffects.Droid", BorderViewRenderer.class, __md_methods);
	}


	public BorderViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BorderViewRenderer.class)
			mono.android.TypeManager.Activate ("XamEffects.Droid.Renderers.BorderViewRenderer, XamEffects.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public BorderViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BorderViewRenderer.class)
			mono.android.TypeManager.Activate ("XamEffects.Droid.Renderers.BorderViewRenderer, XamEffects.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BorderViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BorderViewRenderer.class)
			mono.android.TypeManager.Activate ("XamEffects.Droid.Renderers.BorderViewRenderer, XamEffects.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void dispatchDraw (android.graphics.Canvas p0)
	{
		n_dispatchDraw (p0);
	}

	private native void n_dispatchDraw (android.graphics.Canvas p0);

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
