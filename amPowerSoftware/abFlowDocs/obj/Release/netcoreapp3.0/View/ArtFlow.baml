   M S B A M L   `   `   `  ���� H  DAlbertWPFCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullT:clr-namespace:Albert.Standard.Win32;assembly=AlbertWPFCoreAlbert.Standard.Win32  E AabFlowDocs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:abFlowDocs.ControlsabFlowDocs.Controls    abFlowDocs.View.ArtFlow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Hc:clr-namespace:Albert.Standard.Win32;assembly=AlbertWPFCore     X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  -local!clr-namespace:abFlowDocs.Controls     	viewModel  � DataContext#  [  .���  � RowDefinitions �� $
��auto ��� $
��auto ��� .+�`� .�c�  � ToolTip$ Standard ToolBar��.@�&    Albert.Standard.Win32.PushButton  $ 	StartView��$!��c:DesktopCommands.StartView��   Source$ /Assets/appbar/start.png��  $	 New��$	��New��$ /Assets/appbar/add.png��  $
 Open��$
��Open��$ /Assets/appbar/file.png��  $
 Save��$
��Save��$ /Assets/appbar/save.png��  $ SaveAs��$��c:DesktopCommands.SaveAs��$ /Assets/appbar/saveas.png����   $ Export Image��$��c:DesktopCommands.Export��$# /Assets/appbar/exporticon.png��c� $ Selection Toolbar��.@�  -   
 � Tag$ Paint��$ Brush��$ /Assets/appbar/paint.png��  -   $ Erase��$ Erase by Pont��$ /Assets/appbar/erase.png��  -   $ 	EraseLine��$ Erase by Stroke��$ /Assets/appbar/line.png��  -   $ Select��$ Select Object��$ /Assets/appbar/edit.png���� $��1�� �� Orientation$ 
Horizontal=�.+�&   Xceed.Wpf.Toolkit.DropDownButton  -     Name$ ddBrush��$��1��$��Brush��   DropDownContent #   Albert.Standard.Win32.ZoomBox  .��� $	��350��$	��200�� �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Center=�$��0��$ 
Horizontal=�.+�(   "Albert.Standard.Win32.OptionButton  -   $ Pencil Brush Type��$ Pencil��   Source$ /Assets/pencil.png��  -   $ Pen Brush Type��$	 Pen��$ /Assets/pen.png��  -   $ Marker Brush Type��$ Marker��$ /Assets/marker.png���� -	   	 ��Name$	 cmbBrushSize��$��1��$ Brush Sizes��$
 Size��  	brushSize#��[ ���� *
BrushSizes+  -
   $ ddColor��$��Color��   .��� $	��400��$	��400�� �� �� $
��auto �
 � ColumnDefinitions
 �� �� $
��auto ��� $
��auto �.+�#  Xceed.Wpf.Toolkit.ColorCanvas  -     Name$ colorPicker��$��0��$��0���� $��0��$��1��.+�  -     Name$ optBrush��$ brush��$��4q�
�������$��95��$��95�����	#ff000000  -   $ optBackground��$ 	backgrond��$��4q�
�������$��95��$��95�����	#ffb8b8b8�� $��2��.+�  -   $ 	optPaint1��  optPaint#��[ 
���   �  -   $ 	optPaint2��#��[ 
���  ��  -   $ 	optPaint3��#��[ 
��� ���  -   $ 	optPaint4��#��[ 
��� ���  -   $ 	optPaint5��#��[ 
��� � �  -   $ 	optPaint6��#��[ 
����  �  -   $ 	optPaint7��#��[ 
���� ��  -   $ 	optPaint8��#��[ 
�������  -     Name$ zoomBox��$��2��.��� -    �Name$ gridArtBoard��$��20q�.+��� -    ��Name$ borderArtboard��$	��1.4q�
�������._��� -    ��Name$ artBoard��*   $Albert.Standard.Win32.DocumentDialog  -     Name$ 	dialogNew��  amBackBrush#��[ $��2��.��  .���  �� �� �� 
 �� �� .+��� -    ��Name$ lstSizes��  	artBoards#��[ $��Visible=�  wrap#��[ $
 size��$	��150��$��2������ *	ArtBoards+�� -   $ 	lstThemes��$��1��$��Visible=�  artboardtheme#��[ $ theme��#��[ $��2������ *
ABThemes+�� -    ��Name$ rectSelected��$	��2.5��$��2��$��0��$	��150��$	��150��$��4q��� -    ��Name$ tbSizes��$��2��$��1���� .�Width: �� -    ��Name$ runWidth�� �� $�	 Height: �� �� -    $ 	runHeight��