   M S B A M L   `   `   `  ���� D  @AlbertWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPFAlbert.Standard.Win32  F BamSparkDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:amSparkDesk.ViewamSparkDesk.View )clr-namespace:amSparkDeskamSparkDesk    amSparkDesk.App   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Dc6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPF     ,vclr-namespace:amSparkDesk.View     X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  %localclr-namespace:amSparkDesk    �� 	Resources    amSparkDesk.InkViewModel   inkViewModel   amSparkDesk.SparkViewModel  	viewModel!  amSparkDesk.WebMsgViewModel  wmViewModel  AMBackColor  AMForeColor  AMForeground �� Color  AMBackground  AMAccent  InkPaper (� Stretch �� 
TargetType �� Property �� Value  amSparkDesk.View.QuickInk0  *Xceed.Wpf.Toolkit.Primitives.WindowControl   amSparkDesk.View.QuickNote"  Xceed.Wpf.Toolkit.MessageBox 
	 btnMsg&    Albert.Standard.Win32.PushButton 
 btnNote  
btnRefresh 	 btnGo  
txtWebView#	  Xceed.Wpf.Toolkit.ChildWindow  optColorPick(
   "Albert.Standard.Win32.OptionButton  h2  tbHeader 
 tbTool  amSparkDesk.CodeEditor] YICSharpCode.AvalonEdit, Version=5.0.3.0, Culture=neutral, PublicKeyToken=9cc39be672370310'  !ICSharpCode.AvalonEdit.TextEditor  amSparkDesk.Writer  BackGrid+   %Albert.Standard.Win32.DocumentTabItem��%I  &	        &	      &	 
     &	      &	       &	 1     &	 B     &	 U     &	 i     '��     7  '  G    7  7  7  '  �    7  7  7  '  �    7  7  7  7  7  7  7  7  7  7  7  7  7  7  &		 �    7  7  &	
     7  7  7  &	 ?    7  7  &	 �    7  7  &	 �    '	  ~	    7  7  7  &	 '
    7  7  '�� S    7  7  '�� �    &	 	    7  &	 �    7  '�� �    '�� I    &	 �    7  '�� �    '  _    7  7  7  7  '
  |    7  7  7  'm� �    7  7  '      7  '  �    7  &	 F    7  '�� e    7  '  �    '�� �    7  7  '�� �    7  7  'o� #    7  7  7  7  '�� x          ��#333333����#ffffff���� $ WHite���� $ #333333���� $ DarkBlue���� .R�� .+�(� $
 Fill=�.���� �� ��� *Name+�� �� .�Width: �� ��� *Width+�� �� .�	Height: �� ��� *Height+�� �� " ��.���  � ��8   ��  � ��$ 5���� "  .���  � ��8   ��  � ��8  ��  �@ CaptionForeground8  ��  �@ CaptionFontSize$ 25Q���  � ��$	 500����  � ��$	 400���� "  .���  � ��8   ��  � ��8  ��  �@ CaptionForeground8  ��  �@ CaptionFontSize$ 25Q���  � ��$	 500����  � ��$	 400���� "  .���  � ��8   ��  � ��8  ��  �@ CaptionForeground8  ��  �@ CaptionFontSize$ 25Q���  �@ ButtonRegionBackground8  ��  �@ YesButtonStyle �� " ��.���  � ��8  ��  � ��8  ��  �@ YesButtonStyle �� " ��.���  � ��8  ��  � ��8  ��  �@ NoButtonStyle �� " ��.���  � ��8  ��  � ��8 	 ��  �@ OkButtonStyle �� " ��.���  � ��8 
 ��  � ��8  ��  �@ CancelButtonStyle �� " ��.���  � ��8  ��  � ��8  �� " ��.���  � ��8   ��  � ��8  �� "  .���  � ��$ 50����  � ��$ 50����  � ��$ 5q���  � ��$ Black"���  � ��$ Center=���  � ��8   ��  � ��8  ��  � ��8  ��  �@ BackgroundPressed
 �  ����  �@ BackgroundMouseOver �#0000ff��  �@ ForegroundPressed
 ������� "  .���  � ��$ 50����  � ��$ 50����  � ��$ 5q���  � ��$ Black"���  � ��$ Center=���  � ��
 �  ����  � ��8   ��  � ��8  ��  �@ BackgroundPressed
 �  ����  �@ BackgroundMouseOver �#0000ff��  �@ ForegroundPressed
 ������� "  .���  � ��$ 50����  � ��$ 50����  � ��$ 5q���  � ��$ Black"���  � ��$ Center=���  � ��
 � � ���  � ��8   ��  � ��8  ��  �@ BackgroundPressed
 ������  �@ BackgroundMouseOver �#0000ff��  �@ ForegroundPressed
 ������� " ��.���  � ��$
 auto����  � ��$ 35����  � ��$	 4,7q���  � �� �#ffffff��  � ��$	 2.2q���  � �� �#000000��  � �� �#ffffff�� " 	 .���  � ��8   ��  � ��8  ��  �@ CaptionForeground8  ��  �@ CaptionFontSize$ 25Q���  � ��$	 500����  � ��$	 400���� " 
 .���  � ��$	 120����  � ��$ 5q���  � ��$ 50����  � ��$	 4.9q���  � ��$ Center=���  � ��8   ��  � ��8  ��  �@
 BackgroundChecked �#0000ff��  �@
 BackgroundMouseOver �#0000ff��  �@
 ForegroundChecked
 ������� " ��.���  � ��8   ��  � ��8  �� " ��.���  � ��$
 12pt(���  � ��$ 5q���  � ��
 �������  � ��$ Black"���  � ��$ Center=��� " ��.���  � ��8   ��  �@��TextAlignment$ Center=���  � ��$
 Bold"���  � ��$
 24pt(��� " ��.���  � ��8   ��  �@��TextAlignment$ Center=���  � ��$
 Bold"���  � ��$
 30pt(��� " ��.���  � ��$	 120����  � ��$ 30����  � ��$
 18pt(��� " ��.���  � ��$	 120����  � ��$ Center=��� " ��.���  � ��$
 12pt(���  � ��$ 7q���  � ��8   ��  � ��$ Center=��� " ��.���  � ��$	 210����  � ��$ 35����  � �� �#000000��  � �� �#ffffff�� "  .���  � ��$	 150����  � ��$ 50����  � ��$ 5q���  � ��$ Center=���  � ��8   ��  � ��8  ��  � ��8  ��  �@ BackgroundPressed8  ��  �@ BackgroundMouseOver �#0000ff��  �@ ForegroundPressed
 ������� " 
 .���  � ��$
 Auto����  � ��$	 5,0q���  � ��$ 50����  � ��$ Center=���  � ��8   ��  � ��8  ��  �@
 BackgroundChecked �#0000ff��  �@
 BackgroundMouseOver �#0000ff��  �@
 ForegroundChecked
 �������  � ��8  �� " m�.���  � ��$
 12pt(���  � ��8   ��  � ��8  ��  � ��
 ������� "  .���  � ��$ Courier New)���  �@ WordWrap . ��  � ��$
 24pt(���  �@ ShowLineNumbers . ��  � ��
 �������  � ��8   �� "  .���  �@��
AcceptsTab . ��  �@��AcceptsReturn . ��  � ��$
 24pt(���  � ��
 �������  � ��8   �� " �.���  � ��8   �� " ��.���  � ��8   �� "  .���  � ��$
 18pt(��� " ��.���  � ��8   ��  � ��8  �� " ��.���  � ��8   ��  � ��$
 14pt(���  � ��8  �� " o�.���  � ��8   ��  � ��8  ��  � ��8  ��  � ��8  �� " ��.���  �@��TextDecorations$
 None{���  � ��
 ��ح�