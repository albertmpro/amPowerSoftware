   M S B A M L   `   `   `  ���� D  @AlbertWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPFAlbert.Standard.Win32  I EamFlowDoczBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:amFlowDoczBase.ControlsamFlowDoczBase.Controls !   amFlowDoczBase.View.MsgFlow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dc6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPF     X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  1local%clr-namespace:amFlowDoczBase.Controls  +   %Albert.Standard.Win32.DocumentControl    TopDialogBar  *   $Albert.Standard.Win32.DocumentDialog  -     Name$ dialog��$y�	Collapsed=�.��� .+�#   Albert.Standard.Win32.ZoomBox  -     Name$ gridNew��$y�	Collapsed=�.���    drawViewModel � DataContext# [   � RowDefinitions �� $
��auto ��� �� $
��auto ��� �� $
��auto �.+��� $
��23pt(�$��0��$��Sizes:���� -    ��Name$ lstSizes��
 � Tag$ Sizes��$��1��  docSize#��[   horz#��[ ���� *Sizes+�� $
��23pt(�$��2��$��Themes:���� -   $ lstTheme��$ Theme��$��3�� 	 theme#��[ #��[ ���� *Themes+�� $
��0,20q�$��4�� �� Orientation$ 
Horizontal=�.+��� $��Center=�$
��35pt(��� .�Width: �� -    ��Name$ runWidth�� �� .�	Height: �� -   $ 	runHeight���� -   	 ��Name$	 rectSelefct��$	��4.3��$
��14,0q�$	��150��$	��150��� -   
 �Name$
 
gridExport��$	��400��$y�	Collapsed=� �� $
��auto ��� .+��� $
��Left=�.+�'   !Albert.Standard.Win32.CheckButton  -	     Name$ chkBack��$	��250��$��55��$��Transparent Background��  -
   $ 	chkBorder��$	��250��$��55��$��Transparent Border��.���  �� $
��auto ��� $
��auto ��� .+�`�  `� 
Background �#333333.�c� $��0��.@�&    Albert.Standard.Win32.PushButton   � ToolTip$ 	StartView��$!��c:DesktopCommands.StartView��   Source$ /Assets/appbar/start.png��  $	 New��$	��New��$ /Assets/appbar/add.png��  $
 Open��$
��Open��$ /Assets/appbar/file.png��  $
 Save��$
��Save��$ /Assets/appbar/save.png��  $ SaveAs��$��c:DesktopCommands.SaveAs��$ /Assets/appbar/saveas.png����   $ Expor to Image��$��c:DesktopCommands.Export��$# /Assets/appbar/exporticon.png���� �� -    ��Name$ cmbMode��$ InkFlowState��$	��120��.@��� $	��Ink���� $	��Ref���� $��Theme��c� $��40��.@��� -   $ cmbFont��$	��150��   System.Windows.Media.Fonts   SystemFontFamilies#��Z ��  >   $
 Bold��$ /Assets/appbar/Bold.png��$��
ToggleBold��  toolPush#��[ .��=  $ /Assets/appbar/Italic.png��$ Italic��$��ToggleItalic��#��[   $" /Assets/appbar/underline.png��$ 	Underline��$��ToggleUnderline��#��[ ��   $" /Assets/appbar/leftalign.png��$ 
Left Align��$��	AlignLeft��#��[   $$ /Assets/appbar/centeralign.png��$ Center Align��$��AlignCenter��#��[   $# /Assets/appbar/rightalign.png��$ Right Align��$��
AlignRight��#��[ �� �� $��1��$ 
Horizontal=�.+�&   Xceed.Wpf.Toolkit.DropDownButton  $ Color Properties��$��Colors��   DropDownContent �   amBackBrush#��[  � ColumnDefinitions �� �� $
��auto �.+�#  Xceed.Wpf.Toolkit.ColorCanvas  -     Name$ colorPicker���� $��1��.+�(	   "Albert.Standard.Win32.OptionButton	  -    	 Name$ optText��
�������$ 
Text Color��  optTheme#��[ 	  -   $ optBack��$ Background Color��#��[ 	  -   $ 	optBorder��
�������$ Border Color��#��[   $ Text Box Properties��$
��auto��$	��Box�� � #��[ .+��� .+���   tbNormal#��[ $��Font Size: ��$
��16pt(��� -    ��Name$ 
slFontSize�� � Maximum$	 180Q�$
 Font���� #��[ $��Border Size: ��$
��16pt(��� -   $ slBorder��$	 180Q�$ Border���� #��[ $��Corner Radius: ��$
��16pt(��� -   $ slCorner��$ 45Q�$ Corner��  -   $
 zoom��$��2��$��1��.��)
   #Albert.Standard.Win32.RichTextBlock
  -    
 Name$	 rtb������  �� ElementName$ cmbFont�� �� Path$ SelectedItem�