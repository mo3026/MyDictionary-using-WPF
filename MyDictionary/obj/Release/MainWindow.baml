   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  G CMyDictionary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyDictionaryMyDictionary    MyDictionary.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6sys&clr-namespace:System;assembly=mscorlib     (Kclr-namespace:MyDictionary     Hi:http://schemas.microsoft.com/expression/2010/interactivity       � Title$  MyDictionary��$	��712��$	��534��$	��534��$	��712�� � Icon$ dictionary.ico��
������ $.��(pack://application:,,,/Fonts/#Minion Pro)�$
��13.5(� +� FocusedElement ��  �� ElementName$ TextBoxWord�� � 	Resources    dataFromEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName��%>   &	        S� $ 	GetValues��"   M� $ 
K:Hardness��.���� -   	 ��Name$	 
MainBorder��
 �� CornerRadius$
 20�� &   MyDictionary.BorderClipConverter  ContentClipConverter1��%   &	          J� Clip `�  `� 	Converter# [ .1���  �� Path$ ActualWidth� �� RelativeSource �� *Self+�� $ ActualHeight� �� *Self+�� $ CornerRadius� �� *Self+._�� -    �Name$ grid1�����	#7FFFFFFF.+�� -   $ Item2�� K� ZIndex$ 4�� � RowDefinitions �� $��20 ��� $��* ��� $��20 � � ColumnDefinitions �� $��20 ��� $��* ��� $��20 �.+��� -   $��leftSizeGrip��$��0��$��1��
������ $ 4���� -   $��rightSizeGrip��$��2��$��1��
������ $ 4���� -   $��topSizeGrip��$��1��$��0��
������ $ 4���� -   $��bottomSizeGrip��$��1��$��2��
������ $ 4���� -   $��topLeftSizeGrip��$��0��$��0��
������ $ 4���� -	   $��bottomRightSizeGrip��$��2��$��2��
������ $ 4���� -
   $��topRightSizeGrip��$��2��$��0��
������ $ 4���� -   $��bottomLeftSizeGrip��$��0��$��2��
������ $ 4��� -   $ Item3��$��27��$��0,2,21,0q�$	��Top=�$ 4��.+��� $��0�� �� Orientation$ 
Horizontal=�$��Right=�.+�$  MyDictionary.PDSAucButtonImage  -     Name$ btnMinimize��$  MyDictionary.PDSAucButtonImage   Click$ btnMinimize_Click�� � ToolTip$ Minimize Application��   ImageUri$: 4/MyDictionary;component/ImageButton/Images/Minus.png?�  -   $ btnMaximize��$ btnMaximize_Click��$ Maximize Application��$9 3/MyDictionary;component/ImageButton/Images/Stop.png?�  -   $ btnClose��$ btnClose_Click��$ Close Application��$: 4/MyDictionary;component/ImageButton/Images/Close.png?�� -   $ Item1��$��3��$��3�� � Cursor$
 Hand�����	#7F778899.+��� ���	#19000000 �� RadiusX$ 20�� �� RadiusY$ 20��$��2q�$��0���� ���	#19000000$ 20��$ 20��$��4q�$��0���� ���	#25000000$ 20��$ 20��$��6q�$��0���� ����  �� EndPoint$ 0.4,0.58&� �� 
StartPoint$ 0.6,0.45&�.���  � Color$ 	#0E000000�� � Offset$	 0.0Q�� $ 	#33000000��$
 0.25Q�� $ 	#4C000000��$
 0.45Q�� $ 	#21000000��$
 0.60Q�� $��3��$��3�� �� $��2* ��� $
��5.8* �.+�]� $ 1��$��0��.+�]� $ 1��$
��Left=�.+�   MyDictionary.MoButtonImage  -     Name$ Theme��   MyDictionary.MoButtonImage    Click$  Theme_Click��$	��Top=�$��75��$��75��$��15q�$	��Top=�$ Change Theme��!   ImageUri$,! &/MyDictionary;component/dictionary.ico?�� .+��� $��10,-7,10,00q�$��My Dictionary��$��Center=�$	��Top=�$
��Bold"�$5��//MyDictionary;component/Fonts/#Cooper Std Black)�F� $��0,0,-10,-10q����	#FFC7C7C7$��0��
�������$��Bottom=�$��Bottom=�$��Right=���B� .��E� " E� 
StartPoint$" 58,58&����� # �� Point$# 58,-19&�$ A� 	IsStroked$ .  �� % �� Point$% -19,58&�& �� SweepDirection$& 	Clockwise=�' �� Size$' 69,69���� $# 58,58&�$ .  F� $��	0,0,-8,-8q�$��34��$��Bottom=�$��Bottom=�$��Right=���
� ( 
� GradientOrigin$	( 0,0&�) 
� Center$	) 0,0&�* 
� RadiusY$* 1Q�+ 
� RadiusX$+ 1Q�.��� $
 1.00Q�  
InnerColor# �  � $
 0.81Q�  
OuterColor# [ ��B� .��E� ���� $
# 46,0&�$ .  �� $
% 0,46&�$& 	Clockwise=�$' 46,46��$  MyDictionary.FadingBorderSmall  -   ,  Name$, 
borderWord��-   FadingThickness$- 12Q�.   
InnerColor$. 	#FF373737��  MySpecialTemplateSmall#��[ $ 0��$��
-4,25,5,-9q�
�������$
��Left=�.��� $��0,10,0,0q�$��Center=�
������� �� $��26 ��� $��* ��� $��64 �.+��  �� $	��20* ��� $
��200* ��� $	��20* ��� $	��80* ��� $��5* �.+��� -   / ��Name$/ TextBoxWord��$��Center=�$��0q�$��1���� -   0 ��Name$0 ButtonAddMeaning��$	��Add��$��Center=�$��3��$��0q�{�.  $
��Left=�$��80��� $��1�� �� $��* ��� $��* � �� $	��20* ��� $
��200* ��� $	��20* ��� $	��80* ��� $��5* �.+��� -   1 ��Name$1 ListBoxWords�� 	 Drink#���  $��3��$��1������ .R��� -   $��2,0,0,0q����� $	 Key��� -   $��Remove��$��Center=�$��3��$��0,2,0,0q�$
��Left=�$��80������ 2 �� Triggers2 �� 3 �� Binding3 �� $ ListBoxWords��$ SelectedIndex�4 �� Value4 -1.a��� 5 �� Property5 � {�6 �� Value6 .  �� -   7 ��Name$7 ComboBoxHardnesses��$��3��$
��Left=�$��0q�$��Center=�$��80��$��1������ 8 �� Source#8 [  � $��2��$��0,4,0,0q� �� $	��10* ��� $��9* � �� $	��20* ��� $
��200* ��� $	��20* ��� $	��80* ��� $��5* �.+��� $��0q�$��	Category:��$��Center=�$
��Left=�$��1���� -   $7 ComboBoxCats��  Cats#���  9 �� 
IsEditable9 . $��
62,0,-80,0q�$��1��$��Center=�$��2���� -   $0 ButtonAddCategory��$	��Add��$��1��$��62,0,0,0q�$��Center=�$��80��$
��Left=�$��1���� -   $0 ButtonRemoveCats��$��Remove��$��1��$��Center=�$��3��$��0q�$��80��$
��Left=����� 2 �� 3 �� $ ComboBoxCats��$ SelectedIndex�4 -1.a��� 5 � {�6 .  $  MyDictionary.FadingBorderLarge    MySpecialTemplate#��[ $��5,-4,5,5q�:   FadingThickness$: 12Q�;   
InnerColor$; 	#FF373737��
�������$��1��.��� 
������� �� $	��10* ��� $��9* ��� $	��10* ��� $	��19* �.+��� $��Meaning:��$��
10,4,10,10q�.���  �� $��* ��� $��74 �.+��� -   $/ TextBoxMeaning��< �� TextWrapping$
< Wrap=�= �� AcceptsReturn= . $��10q�$��1������ $ Meaning�> �� Mode$> OneWay=�? �� NotifyOnTargetUpdated? . �� -   $0 ButtonMeaning��$��Center=�$��1��$
��Save��$��68��$
��Left=�� $��1�� �� $��* ��� $��* �.+��� $��Synonym:��$��
10,0,10,10q�.���  �� $��9* ��� $��9* �.+��� -   $/ TextBoxSynonym��$��5q����� $ Synonym�$> OneWay=�? . �� -   $0 ButtonSynonym��$
��Save��$��1��$��Center=�$
��69,0q��� $��antonym:��$��
10,0,10,10q�$��1��.���  �� $��9* ��� $��9* �.+��� -    $/ TextBoxantonym��$��5q����� $ Antonym�$> OneWay=�? . �� -!   $0 Buttonantonym��$
��Save��$��1��$��Center=�$
��69,0q��� $��Example:��$��
10,0,10,10q�$��2��.���  �� $��* ��� $��74 �.+��� -"   $/ TextBoxExample��$
< Wrap=�= . $��10q�$��1������ $ Example�$> OneWay=�? . �� -#   $0 ButtonExample��$��Center=�$��1��$
��Save��$
��Left=�$��68��� $��3��$��0,0,0,10q� �� $��* ��� $��* � �� $��7* ��� $��8* �.+��� $��	Category:��$��	10,0,10,0q�$��90��.���  �� $	��10* ��� $��9* �.+��� -$   $7 ComboBoxCat��#���  $��5q�@ �� SelectedItem@ �� $ Category�$> OneWay=�? . �� -%   $0 ButtonCategory��$
��Save��$��1��$��Center=�$
��60,0q��� $��	Hardness:��$��	10,0,10,0q�$��1��$��90��.���  �� $	��10* ��� $��9* �.+��� -&   $7 ComboBoxHardness��$��5q�@ �� $ Hardness�$> OneWay=�? . ���� #8 [  �� -'   $0 ButtonHardness��$
��Save��$��1��$��Center=�$
��60,0q�� -(   $
 grid��$��1��$��2��$��	-20,0,0,0q�.+�� $��Center=� �� $��* ��� $��* � �� $	��161������ $
 grid��$ Height��� .+��� -)   A ��Name$A ListViewImages��$��Disabled=�$��2������ $ Images�? . ���� $ ActualHeight� �� *Self+���� .R�� B �Name$B g������ $ ActualHeight�$ ListViewImages������ .R�� ���� $ Height�$ g��.+��� -*   $��1q�
�������$��0,0,0,28q� _� ���� *PixelHeight+$> OneWay=����� *
PixelWidth+$> OneWay=�.���� $��Center=�$��Center=�$��Uniform=����� ._��� ���� �� -+   $0 ButtonAddImages��$	��Add��$��Center=�{�.  $��68��$��1��$
��Left=�$��10,0,0,0q��� -,   $��1��$��1��$��Remove��$��Center=�$��68��$
��Left=�$��10,0,0,0q����� 2 �� 3 �� $ ListViewImages��$ SelectedIndex�4 -1.a��� 5 � {�6 .  