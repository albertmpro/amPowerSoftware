   M S B A M L   `   `   `  ���� A  =Albert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA-clr-namespace:Albert.Standard;assembly=AlbertAlbert.Standard  D @AlbertWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPFAlbert.Standard.Win32 I EamFlowDoczBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:amFlowDoczBase.ControlsamFlowDoczBase.Controls !   amFlowDoczBase.View.InkFlow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  :d2http://schemas.microsoft.com/expression/blend/2008  6ab-clr-namespace:Albert.Standard;assembly=Albert  >c6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPF  1local%clr-namespace:amFlowDoczBase.Controls  -   )  #amFlowDoczBase.Controls.ThemeScreen   Name$  inkFlow��   drawViewModel � DataContext# [  +  %Albert.Standard.Win32.DocumentControl   TopDialogBar *  $Albert.Standard.Win32.DocumentDialog  -     Name$ dialog��$y�	Collapsed=�.��� .+�#  Albert.Standard.Win32.ZoomBox  -     Name$ gridNew��$y�	Collapsed=�.��� # [   � RowDefinitions �� $
��auto ��� �� $
��auto ��� �� $
��auto �.+��� $
��23pt(�$��0��$��Sizes:���� -    ��Name$ lstSizes��
 � Tag$ Sizes��$��1��  docSize#��[   horz#��[ ���� *Sizes+�� $
��23pt(�$��2��$��Themes:���� -   $ lstTheme��$ Theme��$��3�� 	 theme#��[ #��[ ���� *Themes+�� $
��0,20q�$��4�� �� Orientation$ 
Horizontal=�.+��� $��Center=�$
��35pt(��� .�Width: �� -   	 ��Name$	 runWidth�� �� .�	Height: �� -   $	 	runHeight���� -   
 ��Name$
 rectSelefct��$	��4.3��$
��14,0q�$	��150��$	��150��� -	    �Name$ 
gridExport��$	��400��$y�	Collapsed=� �� $
��auto ��� .+��� $
��Left=�.+�'  !Albert.Standard.Win32.CheckButton  -
     Name$ chkBack��$	��250��$��55��$��Transparent Background��.���   amBackBrush#��[  �� $
��auto ��� $
��auto ��� .+�c� $��0��.@�&   Albert.Standard.Win32.PushButton   � ToolTip$ 	StartView��$!��c:DesktopCommands.StartView��   Source$ /Assets/appbar/start.png��  $	 New��$	��New��$ /Assets/appbar/add.png��  $
 Open��$
��Open��$ /Assets/appbar/file.png��  $
 Save��$
��Save��$ /Assets/appbar/save.png��  $ SaveAs��$��c:DesktopCommands.SaveAs��$ /Assets/appbar/saveas.png����   $ Expor to Image��$��c:DesktopCommands.Export��$# /Assets/appbar/exporticon.png���� �� -    ��Name$ cmbMode��$ InkFlowState��$	��120��.@��� $	��Ink���� $	��Ref���� $��Theme���� $��1��$��45��$ 
Horizontal=�.+�&   Xceed.Wpf.Toolkit.DropDownButton  $ Redifine INc Canvas Sizes��$	��Box��   DropDownContent � .+��� -   $ cmbSizes��$ Preset Sizes��  simplePaper#��[ .@�   Albert.Standard.DrawPaper     Width$
 1920Q�   Height$
 1080Q�  $
 1080Q�$
 1920Q�  $
 1080Q�$
 1080Q�  $
 1365Q�$	 768Q�  $
 1024Q�$
 1024Q�  $	 504Q�$	 504Q�  $	 300Q�$	 300Q�  $	 100Q�$	 100Q�  $ Selection Options��$��	Selection�� � .+�� .+�(	  "Albert.Standard.Win32.OptionButton	  -   $ 	Draw Tool��$
 Draw�� 	  Source$ /Assets/appbar/paint.png��	  -   $ 
Erase Tool��$ Erase��$ /Assets/appbar/erase.png��	  -   $ Erase by Stroke��$ EraseStroke��$ /Assets/appbar/line.png��	  -   $ 
Select Ink��$ Select��$ /Assets/appbar/trace.png��  $ Brush Options��$��Brushes��   .��� #��[ $	��350�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0�� �� TextAlignment$ Right=�  tbNormal#��[ $��Size:���� -    ��Name$ slSize�� � Maximum$ 80Q�$ 
Brush Size��$��1��$��1���� -    ��Name$ 
borderSize��$��15��$��15��$��2��$��Center=� �� CornerRadius$ 15��
�������� $��3��.+�  -   $ Brush Size 3px��$ b3��$��90��$��90��.��A� $��3��$��3��
�������  -   $ BrushSize 7px��$ b7��$��90��$��90��.��A� $��7��$��7��
�������  -   $ Brush Size 10px��$	 b10��$��90��$��90��.��A� $��10��$��10��
�������  -   $ Brush Size 15px��$	 b15��$��90��$��90��.��A� $��15��$��15��
�������  -   $ Brush Size 20px��$	 b20��$��90��$��90��.��A� $��20��$��20��
�������  -   $ Brush Size 35px��$	 b35��$��90��$��90��.��A� $��35��$��35��
�������  -   $ Brush Size 50px��$	 b50��$��90��$��90��.��A� $��50��$��50��
�������  -   $ Brush Size 55px��$	 b55��$��90��$��90��.��A� $��55��$��55��
�������  -   $ Brush Size 60px��$	 b60��$��90��$��90��.��A� $��60��$��60��
�������  -   $ Brush Size 65px��$	 b65��$��90��$��90��.��A� $��65��$��65��
�������  $ Color Options��$��Colors�� � #��[  � ColumnDefinitions �� �� $
��auto �.+�#
  Xceed.Wpf.Toolkit.ColorCanvas
  -    
 Name$ colorPicker���� $��Center=�$��1��.+�	  -    	 Name$ optBrush��
�������$ Brush Color��  optTheme#��[ $��3q�$	��120��	  -   $ optBackground��$ Background Color��#��[ 
���   �$��3q�$	��120��� -    $ gridMain��$��2��.+�  -!   $ 	zoomTheme��.��� -"   $ 	gridTheme�� �� �� $
��auto �.+�
  -#   $ themePicker��$ Theme Color Picker���� $��1��.+�	  -$   $ 	optColor1��$ Color 1��#��[ ����  �� Color ��  �� ElementName$ inkFlow�� �� Path$ ColorOne�	  -%   $ 	optColor2��$ Color 2��#��[ ����  �� $ inkFlow��$ ColorTwo�	  -&   $ 	optColor3��$ Color 3��#��[ ����  �� $ inkFlow��$ 
ColorThree�	  -'   $ 	optColor4��$ Color 4��#��[ ����  �� $ inkFlow��$ 	ColorFour�	  -(   $ 	optColor5��$ Color 5��$��90��#��[ ����  �� $ inkFlow��$ 	ColorFive�