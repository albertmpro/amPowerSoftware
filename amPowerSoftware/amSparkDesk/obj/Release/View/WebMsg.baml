   M S B A M L   `   `   `  ���� D  @AlbertWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPFAlbert.Standard.Win32  F BamSparkDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:amSparkDesk.ViewamSparkDesk.View    amSparkDesk.View.WebMsg   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Dc6clr-namespace:Albert.Standard.Win32;assembly=AlbertWPF     X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  :d2http://schemas.microsoft.com/expression/blend/2008  *localclr-namespace:amSparkDesk.View     wmViewModel  � DataContext#  [  .��!   Albert.Standard.Win32.ADock  -     Name$
 dock��   Stretch$ Uniform=�   TopBar �� $��45�� �� Orientation$ 
Horizontal=�.+��� $��Font Family:���� -    ��Name$ cmbFont��   System.Windows.Media.Fonts   SystemFontFamilies#��Z �� $��Size:���� -    ��Name$ slideFontSize�� � Value$ 20Q�	 � Minimum$	 15Q�
 � Maximum$
 80Q�$	��120���� $��Align:��(   "Albert.Standard.Win32.OptionButton  -   
 � Tag$
 Left��$��L��  -   $ Center��$��C��  -   $ Right��$��R���� $��Border:���� -   $ slideBorder��$	��120��$
 14Q�.��&    Albert.Standard.Win32.ATextField  -     Name$	 txt�� �� 
AcceptsTab .  �� AcceptsReturn .    
TextMargin$ 14q�   CornerRadius$ 12��$��45(� �� 	IsEnabled . $	��504��$	��504�� �� TextWrapping$
 Wrap=�$	��3.5q�
�����������  �� ElementName$ cmbFont�� �� Path$ SelectedItem�.��   RightBar (�  (� Stretch$ Uniform=�$	��Top=�$
��Left=�.���� .+�#  Xceed.Wpf.Toolkit.ColorCanvas  -	     Name$ colorPicker��
�������  AMBackground#��[   -
     Name$ optBack��  optColorPick#��[ $��
Background������ $	 txt��$ 
Background�  -   $ optText��#��[ $
��Text������ $	 txt��$ 
Foreground�  -   $ 	optBorder��#��[ $��Border������ $	 txt��$ BorderBrush�