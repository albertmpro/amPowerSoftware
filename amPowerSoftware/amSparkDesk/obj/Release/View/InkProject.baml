   M S B A M L   `   `   `  ���� A  =Albert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA-clr-namespace:Albert.Standard;assembly=AlbertAlbert.Standard  D @AlbertWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPFAlbert.Standard.Win32 F BamSparkDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:amSparkDesk.ViewamSparkDesk.View !   amSparkDesk.View.InkProject   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <st-clr-namespace:Albert.Standard;assembly=Albert     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dc6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPF     0localclr-namespace:amSparkDesk.View     X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit     inkViewModel  � DataContext#  [  .��� .+�!  Albert.Standard.Win32.ADock     Stretch$ Uniform=�   TopBar ��  �� Orientation$ 
Horizontal=�.+���  
 tbTool#��[ $��	DrawSize:���� -    ��Name$ 	slideSize�� � Maximum$ 90Q� � Value$ 15Q��� $��Presets:��(  "Albert.Standard.Win32.OptionButton  -   
 � Tag$
 Thin��$
��Thin��  -   $	 Pen��$	��Pen��  -   $ Marker��$��Marker��  -   $ Paint��$��Paint���� #��[ $��	DrawSize:��   LeftBar �� .+�  -   $	��0,4q�$	 Ink��	 � ToolTip$	 Draw Ink��.���� $��/Assets/appbar/paint.png��  -   $	��0,4q�$ Erase��$	 Erase��.���� $��/Assets/appbar/erase.png��  -   $	��0,4q�$ EraseS��$	 Erase by Stroke ��.���� $��/Assets/appbar/clear.png��  -	   $	��0,4q�$ Select��$	 Selection Tool ��.���� $��/Assets/appbar/status.png��.��� -
   
 �Name$
 gridContent��.+��� -    ��Name$ 	inkCanvas�� �� 
Background �#000000$
��1920��$
��1080�� �� DefaultDrawingAttributes *  $System.Windows.Ink.DrawingAttributes     Color$ #ffffff��-   drawAtt��   Height$ 10Q�   Width$ 10Q�   RightBar (�  (� Stretch$ Uniform=�$	��Top=�$
��Left=�.���� .+�#  Xceed.Wpf.Toolkit.ColorCanvas  -     Name$ colorPicker��
�������  AMBackground#��[   -     Name$ optBack��  optColorPick#��[ $��
Background������  �� ElementName$ 	inkCanvas�� �� Path$ 
Background�  -   $ optBrush��#��[ $��Paint Brush��   	BottomBar �� $ 
Horizontal=�#  Xceed.Wpf.Toolkit.ChildWindow  -     Name$ 
winNewItem��0  *Xceed.Wpf.Toolkit.Primitives.WindowControl   Caption$ New Item��.���  � RowDefinitions �� �� $
��auto � � ColumnDefinitions �� �� .+��� $��Prests���� -    ��Name$ 
cmbPresets��  InkPaper#��[ ���� *Papers+�� -    ��Name$ tbNewInk��$��1��$
��21pt(��� .�Width:�� �� -    ��Name$ runWidth���� �� .�	Height: �� -   $ 	runHeight���� $��1��$��2��$ 
Horizontal=�.+�&   Albert.Standard.Win32.PushButton  -     Name$ btnOk��$��Ok��$ Ok��  -   $ 	btnCancel��$��Cancel��$ Cancel��  -   $ 	winExport��$ Export��.��� .+��� .+��� -     ��Name$  chkTransparent��$��Background is Transparnet���� $ 
Horizontal=�.+�  -   $ Export��$��Export��  -   $ Cancel��$��Cancel��