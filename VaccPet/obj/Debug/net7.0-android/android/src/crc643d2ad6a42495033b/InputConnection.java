package crc643d2ad6a42495033b;


public class InputConnection
	extends android.view.inputmethod.BaseInputConnection
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_closeConnection:()V:GetCloseConnectionHandler\n" +
			"n_beginBatchEdit:()Z:GetBeginBatchEditHandler\n" +
			"n_commitText:(Ljava/lang/CharSequence;I)Z:GetCommitText_Ljava_lang_CharSequence_IHandler\n" +
			"n_sendKeyEvent:(Landroid/view/KeyEvent;)Z:GetSendKeyEvent_Landroid_view_KeyEvent_Handler\n" +
			"n_setSelection:(II)Z:GetSetSelection_IIHandler\n" +
			"n_performContextMenuAction:(I)Z:GetPerformContextMenuAction_IHandler\n" +
			"n_getSelectedText:(I)Ljava/lang/CharSequence;:GetGetSelectedText_IHandler\n" +
			"n_getExtractedText:(Landroid/view/inputmethod/ExtractedTextRequest;I)Landroid/view/inputmethod/ExtractedText;:GetGetExtractedText_Landroid_view_inputmethod_ExtractedTextRequest_IHandler\n" +
			"n_getTextAfterCursor:(II)Ljava/lang/CharSequence;:GetGetTextAfterCursor_IIHandler\n" +
			"n_getTextBeforeCursor:(II)Ljava/lang/CharSequence;:GetGetTextBeforeCursor_IIHandler\n" +
			"";
		mono.android.Runtime.register ("Material.Components.Maui.Core.InputConnection, Material.Components.Maui", InputConnection.class, __md_methods);
	}


	public InputConnection (android.view.View p0, boolean p1)
	{
		super (p0, p1);
		if (getClass () == InputConnection.class) {
			mono.android.TypeManager.Activate ("Material.Components.Maui.Core.InputConnection, Material.Components.Maui", "Android.Views.View, Mono.Android:System.Boolean, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public void closeConnection ()
	{
		n_closeConnection ();
	}

	private native void n_closeConnection ();


	public boolean beginBatchEdit ()
	{
		return n_beginBatchEdit ();
	}

	private native boolean n_beginBatchEdit ();


	public boolean commitText (java.lang.CharSequence p0, int p1)
	{
		return n_commitText (p0, p1);
	}

	private native boolean n_commitText (java.lang.CharSequence p0, int p1);


	public boolean sendKeyEvent (android.view.KeyEvent p0)
	{
		return n_sendKeyEvent (p0);
	}

	private native boolean n_sendKeyEvent (android.view.KeyEvent p0);


	public boolean setSelection (int p0, int p1)
	{
		return n_setSelection (p0, p1);
	}

	private native boolean n_setSelection (int p0, int p1);


	public boolean performContextMenuAction (int p0)
	{
		return n_performContextMenuAction (p0);
	}

	private native boolean n_performContextMenuAction (int p0);


	public java.lang.CharSequence getSelectedText (int p0)
	{
		return n_getSelectedText (p0);
	}

	private native java.lang.CharSequence n_getSelectedText (int p0);


	public android.view.inputmethod.ExtractedText getExtractedText (android.view.inputmethod.ExtractedTextRequest p0, int p1)
	{
		return n_getExtractedText (p0, p1);
	}

	private native android.view.inputmethod.ExtractedText n_getExtractedText (android.view.inputmethod.ExtractedTextRequest p0, int p1);


	public java.lang.CharSequence getTextAfterCursor (int p0, int p1)
	{
		return n_getTextAfterCursor (p0, p1);
	}

	private native java.lang.CharSequence n_getTextAfterCursor (int p0, int p1);


	public java.lang.CharSequence getTextBeforeCursor (int p0, int p1)
	{
		return n_getTextBeforeCursor (p0, p1);
	}

	private native java.lang.CharSequence n_getTextBeforeCursor (int p0, int p1);

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
