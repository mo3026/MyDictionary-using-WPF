   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   G CMyDictionary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyDictionaryMyDictionary 5   	      MyDictionary.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   (Kclr-namespace:MyDictionary     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	     � Title$  MyDictionary��5   	   $	��712��6   $	��534��6+   $	��550��5   	   $	��775��5	   	    � Icon$ dictionary.ico��5
   I   
������ $.��(pack://application:,,,/Fonts/#Minion Pro)�6x   $
��13.5(�6�    +� FocusedElement 6	   ��  �� ElementName$ TextBoxWord�� � 	Resources 5         dataFromEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName��%u   &	        S� 5   
   $ 	GetValues��5      "  6    5      M� 5      $ 
K:Hardness��6   5      5      .��5      �� -   5        	 ��Name$	 
MainBorder��5      
 �� CornerRadius$
 20��6!    5   
   &   MyDictionary.BorderClipConverter  ContentClipConverter1��%   &	         5      6$   5       J� Clip 5   
   `� 5       `� 	Converter# [ 6   .1�5      ��  �� Path$ ActualWidth�6    �� RelativeSource 5      �� *Self+�� 5      $ ActualHeight�6    5      �� *Self+�� 5      $ CornerRadius�6    5      �� *Self+5      ._�5!   
   � -   5         �Name$ grid1��5!      ���	#7FFFFFFF.+�5#      � -   5        $ Item2��5#       � RowDefinitions 5$      �� 5%      $��20 �6$   62   �� 5&      $��* �6$   61   �� 5'      $��20 �6$   62    � ColumnDefinitions 5)      �� 5*      $��20 �6'   64   �� 5+      $��* �6'   63   �� 5,      $��20 �6'   64   .+�50      �� -   5        $��leftSizeGrip��50   9   $��0��6   $��1��6,   
������  K� ZIndex$ 4��6`   �� 51      -   5        $��rightSizeGrip��51   9   $��2��6   $��1��6,   
������ $ 4��6b   �� 52      -   5        $��topSizeGrip��52   H    � Cursor$
 Hand��6   $��1��6+   $��0��6;   
������ $ 4��6o   6�   �� 53      -   5        $��bottomSizeGrip��53   9   $��1��6   $��2��6,   
������ $ 4��6c   �� 55      -   5        $��topLeftSizeGrip��55   9   $��0��6   $��0��6,   
������ $ 4��6d   �� 56      -	   5        $��bottomRightSizeGrip��56   9   $��2��6   $��2��6,   
������ $ 4��6h   �� 57      -
   5        $��topRightSizeGrip��57   9   $��2��6   $��0��6,   
������ $ 4��6e   �� 58      -   5        $��bottomLeftSizeGrip��58   9   $��0��6   $��2��6,   
������ $ 4��6g   59      � 5;      -   5        $ Item3��5;   h   $
 Hand��6   $��27��6!   $��0,8,21,0q�6-   $	��Top=�6?   $ 4��6W   .+�5<      �� $��Center=�6   $��Center=�69   $��My Dictionary��6T   $
��Bold"�6i   $5��//MyDictionary;component/Fonts/#Cooper Std Black)�6|   �� 5=      $��0��6    �� Orientation$ 
Horizontal=�5>      $��Right=�5?      .+�5@      $  MyDictionary.PDSAucButtonImage  -   5          Name$ btnMinimize��5@   *   $  MyDictionary.PDSAucButtonImage   Click$ btnMinimize_Click��5A       � ToolTip$ Minimize Application��5B         ImageUri$: 4/MyDictionary;component/ImageButton/Images/Minus.png?�5C        5D      -   5        $ btnMaximize��5D   *   $ btnMaximize_Click��5E      $ Maximize Application��5F      $9 3/MyDictionary;component/ImageButton/Images/Stop.png?�5G        5H      -   5        $ btnClose��5H   *   $ btnClose_Click��5I      $ Close Application��5J      $: 4/MyDictionary;component/ImageButton/Images/Close.png?�5K      5L      5M      � 5O      -   5        $ Item1��5O   F   $��3��6   $��3��6$   $
 Hand��68   ���	#7F778899.+�5P      �� ���	#19000000 �� RadiusX$ 20��6-    �� RadiusY$ 20��6:   $��2q�6G   $��0��6R   �� 5Q      ���	#19000000$ 20��6-   $ 20��6:   $��4q�6G   $��0��6R   �� 5R      ���	#25000000$ 20��6-   $ 20��6:   $��6q�6G   $��0��6R   �� 5S      ��5T      �� 5U       �� EndPoint$ 0.4,0.58&�6.    �� 
StartPoint$ 0.6,0.45&�6B   .��5V      �  � Color$ 	#0E000000��6+    � Offset$	 0.0Q�6=   � 5W      $ 	#33000000��6+   $
 0.25Q�6=   � 5X      $ 	#4C000000��6+   $
 0.45Q�6=   � 5Y      $ 	#21000000��6+   $
 0.60Q�6=   5Z      5\      5]      � 5_      $��3��6   $��3��6$    5`      �� 5a      $��2* �6$   �� 5b      $
��5.8* �6$   .+�5d      ]� $ 1��6   $��0��6-   .+�5e      ]� $ 1��6    $
��Left=�62   .+�5f      �� -   5         ��Name$ Theme��5f       $	��Top=�6/   $��75��6D   $��75��6O   $��
15,42,15,0q�6[   $	��Top=�6o   $ Change Theme��5g      $,��&/MyDictionary;component/dictionary.ico��5h      5i      � 5k      .+�5l      �� $��10,-7,10,00q�6(   $��My Dictionary��6=   $��Center=�6R   $	��Top=�6o   $
��Bold"�6�   $5��//MyDictionary;component/Fonts/#Cooper Std Black)�6�   ���	#000000006�   F� 5m      $��0,0,-10,-10q�6#   ���	#FFC7C7C7$��0��6K   
�������$��Bottom=�6l   $��Bottom=�6�   $��Right=�6�   ��5n   "   B� 5o   &   .��5p   *   E�   E� 
StartPoint$  58,58&�65   ��5r   2   �� ! �� Point$! 58,-19&�6>   " A� 	IsStroked" .  6M   �� 5s   2   # �� Point$# -19,58&�6=   $ �� SweepDirection$$ 	Clockwise=�6L   % �� Size$% 69,69��6g   �� 5t   2   $! 58,58&�6>   " .  6L   5v   +   5w   '   5y      F� 5z      $��	0,0,-8,-8q�6#   $��34��66   $��Bottom=�6K   $��Bottom=�6c   $��Right=�6~   ��5{   "   
� 5|   &   & 
� GradientOrigin$	& 0,0&�6;   ' 
� Center$	' 0,0&�6P   ( 
� RadiusY$( 1Q�6^   ) 
� RadiusX$) 1Q�6j   .��5}   *   � $
 1.00Q�67     
InnerColor# �  6E   � 5~   *   $
 0.81Q�67     
OuterColor# [ 6E   5   '   ��5�   "   B� 5�   &   .��5�   *   E� ��5�   2   �� $
! 46,0&�6>   " .  6K   �� 5�   2   $
# 0,46&�6=   $$ 	Clockwise=�6J   $% 46,46��6e   5�   +   5�   '   5�      5�      5�      $  MyDictionary.FadingBorderSmall  5�      -   5        *  Name$* 
borderWord��5�   �   +   FadingThickness$+ 12Q�6*   ,   
InnerColor$, 	#FF373737��6?     MySpecialTemplateSmall#��[ 6V   $ 0��6�   $��
-4,35,5,-9q�6�   
�������$
��Left=�6�   .��5�      � $��0,10,0,0q�6   $��Center=�61   
������� 5�      �� 5�   "   $��26 �60   �� 5�   "   $��* �60   �� 5�   "   $��64 �60   .+�5�      �  5�   "   �� 5�   &   $	��20* �67   �� 5�   &   $
��200* �67   �� 5�   &   $	��20* �67   �� 5�   &   $	��80* �67   �� 5�   &   $��5* �67   .+�5�   "   �� -   5        - ��Name$- TextBoxWord��5�   *   $��Center=�6?   $��0q�6Z   $��1��6�   �� 5�   "   -   5        . ��Name$. ButtonAddMeaning��5�   )   $	��Add��6C   $��Center=�6Q   $��3��6l   $��0q�6|   {�.  $
��Left=�6�   $��80��6�   5�      � 5�      $��1��6#    5�   "   �� 5�   &   $��* �64   �� 5�   &   $��* �64    5�   "   �� 5�   &   $	��20* �67   �� 5�   &   $
��200* �67   �� 5�   &   $	��20* �67   �� 5�   &   $	��80* �67   �� 5�   &   $��5* �67   .+�5�   "   �� -   5        / ��Name$/ ListBoxWords��5�   *    	 Drink#���  6@   $��3��6�   $��1��6�   ��5�   &   �� 5�   *   .R�5�   .   �� -   5        $��2,0,0,0q�5�   R   ��68   �� $	 Key�6c   5�   +   5�   #   �� 5�   "   -   5        $��Remove��5�   )   $��Center=�6:   $��3��6U   $��0,2,0,0q�6e   $
��Left=�6v   $��80��6�   ��5�   &   �� 5�   *   0 �� Triggers0 5�   .   �� 5�   2   1 �� Binding1 5�      �� $ ListBoxWords��$ SelectedIndex�2 �� Value2 -15�      .a�5�   6   �� 3 �� Property3 � {�4 �� Value4 .  6Y   5�   3   5�   +   5�   #   �� 5�   "   -   5        5 ��Name$5 ComboBoxHardnesses��5�   +   $��3��6�   $
��Left=�6�   $��0q�6�   $��Center=�6�   $��80��6�   $��1��6  ��6G   �� 6 �� Source#6 [  6  5�      � 5�      $��2��6#   $��0,4,0,0q�60    5�   "   �� 5�   &   $	��10* �64   �� 5�   &   $��9* �64    5�   "   �� 5�   &   $	��20* �67   �� 5�   &   $
��200* �67   �� 5�   &   $	��20* �67   �� 5�   &   $	��80* �67   �� 5�   &   $��5* �67   .+�5�   "   �� $��0q�6(   $��	Category:��63   $��Center=�6G   $
��Left=�6b   $��1��6}   �� 5�   "   -   5        $5 ComboBoxCats��5�   +     Cats#���  6u   7 �� 
IsEditable7 . $��
62,0,-80,0q�6�   $��1��6�   $��Center=�6  $��2��6  �� 5�   "   -   5        $. ButtonAddCategory��5�   )   $	��Add��6D   $��1��6S   $��62,0,0,0q�6`   $��Center=�6�   $��80��6�   $
��Left=�6�   $��1��6�   �� 5�   "   -   5        $. ButtonRemoveCats��5�   )   $��Remove��6C   $��1��6U   $��Center=�6b   $��3��6}   $��0q�6�   $��80��6�   $
��Left=�6�   ��5�   &   �� 5�   *   0 5�   .   �� 5�   2   1 5�      �� $ ComboBoxCats��$ SelectedIndex�2 -15�      .a�5�   6   �� 3 � {�4 .  6Y   5�   3   5�   +   5�   #   5�      5�      5�      5�      $  MyDictionary.FadingBorderLarge  5�        MySpecialTemplate#��[ 6&   $��5,-4,5,5q�6T   8   FadingThickness$8 12Q�6f   9   
InnerColor$9 	#FF373737��6{   
�������$��1��6�   .��5�      � 
������� 5�      �� 5�      $	��10* �6,   �� 5�      $��9* �6,   �� 5�      $	��10* �6,   �� 5�      $	��19* �6,   .+�5�      �� $��Meaning:��6#   $��
10,4,10,10q�65   .��5�      �  5�   "   �� 5�   &   $��* �67   �� 5�   &   $��74 �67   .+�5�   "   �� -   5        $- TextBoxMeaning��5�   T   : �� TextWrapping$
: Wrap=�6*   ; �� AcceptsReturn; . $��10q�6�   $��1��6�   ��6l   �� $ Meaning�< �� Mode$< OneWay=�= �� NotifyOnTargetUpdated= . 6�   �� 5�   "   -   5        $. ButtonMeaning��5�   )   $��Center=�6@   $��1��6[   $
��Save��6k   $��68��6�   $
��Left=�6�   5�      5�      � 5�      $��1��6    5�      �� 5�   "   $��* �63   �� 5�   "   $��* �63   .+�5�      �� $��Synonym:��6'   $��
10,0,10,10q�69   .��5�   "   �  5�   &   �� 5�   *   $��9* �68   �� 5   *   $��9* �68   .+�5  &   �� -   5        $- TextBoxSynonym��5  .   $��5q�6F   ��6Q   �� $ Synonym�$< OneWay=�= . 6�   �� 5  &   -   5        $. ButtonSynonym��5  -   $
��Save��6D   $��1��6T   $��Center=�6a   $
��69,0q�6|   6�   5  #   5     �� 5     $��antonym:��6'   $��
10,0,10,10q�69   $��1��6M   .��5  "   �  5  &   �� 5	  *   $��9* �68   �� 5
  *   $��9* �68   .+�5  &   �� -    5        $- TextBoxantonym��5  .   $��5q�6F   ��6Q   �� $ Antonym�$< OneWay=�= . 6�   �� 5  &   -!   5        $. Buttonantonym��5  -   $
��Save��6D   $��1��6T   $��Center=�6a   $
��69,0q�6|   6�   5  #   5     5     �� 5     $��Example:��6#   $��
10,0,10,10q�65   $��2��6I   .��5     �  5  "   �� 5  &   $��* �67   �� 5  &   $��74 �67   .+�5  "   �� -"   5        $- TextBoxExample��5  T   $
: Wrap=�6*   ; . $��10q�6�   $��1��6�   ��6l   �� $ Example�$< OneWay=�= . 6�   �� 5  "   -#   5        $. ButtonExample��5  )   $��Center=�6@   $��1��6[   $
��Save��6k   $
��Left=�6�   $��68��6�   5     5     � 5     $��3��6   $��0,0,0,10q�6,    5     �� 5   "   $��* �60   �� 5!  "   $��* �60    5#     �� 5$  "   $��7* �63   �� 5%  "   $��8* �63   .+�5'     �� $��	Category:��6'   $��	10,0,10,0q�6:   $��90��6M   .��5(  "   �  5)  &   �� 5*  *   $	��10* �68   �� 5+  *   $��9* �68   .+�5-  &   �� -$   5        $5 ComboBoxCat��5-  /   #���  6�   $��5q�6�   > �� SelectedItem> 6F   �� $ Category�$< OneWay=�= . 6�   �� 5.  &   -%   5        $. ButtonCategory��5.  -   $
��Save��6E   $��1��6U   $��Center=�6b   $
��60,0q�6}   6�   5/  #   50     �� 51     $��	Hardness:��6'   $��	10,0,10,0q�6:   $��1��6M   $��90��6Z   .��52  "   �  53  &   �� 54  *   $	��10* �68   �� 55  *   $��9* �68   .+�57  &   �� -&   5        $5 ComboBoxHardness��57  /   $��5q�6�   > 6I   �� $ Hardness�$< OneWay=�= . ��6�   �� #6 [  6	  �� 58  &   -'   5        $. ButtonHardness��58  -   $
��Save��6E   $��1��6U   $��Center=�6b   $
��60,0q�6}   6�   59  #   5:     � 5<     -(   5        $
 grid��5<  #   $��1��62   $��2��6B   $��	-20,0,0,0q�6S   .+�5=  "   � $��Center=�6'    5>  &   �� 5?  *   $��* �68   �� 5@  *   $��* �68    5B  &   �� 5C  *   $	��161��6l   ��6;   �� $
 grid��$ Height�6l   �� 5D  *   .+�5F  &   �� -)   5        ? ��Name$? ListViewImages��5F  c   $��Disabled=�6/   $��2��5G  W   ��5F  |   �� $ Images�= . ��5G     �� $ ActualHeight� �� *Self+��5H  *   �� 5I  .   .R�5J  2   � @ �Name$@ g��6}   ��6<   �� $ ActualHeight�$ ListViewImages��6}   5K  /   ��5M  *   �� 5N  .   .R�5O  2   � ��67   �� $ Height�$ g��.+�5P  6   �� -*   5        $��1q�5P  ]   
�������$��0,0,0,28q�6�    5Q  :   _� 5R  >   ��6F   �� *PixelHeight+$< OneWay=���6q   �� *
PixelWidth+$< OneWay=�.��5S  B   �� $��Center=�6H   $��Center=�6c   $��Uniform=�6�   ��6�   �� 6�   5T  ?   ._�5V  :   �� ��6@   �� 5W  7   5X  3   5Y  /   5[  '   �� 5^  &   -+   5        $. ButtonAddImages��5^  -   $	��Add��6F   $��Center=�6T   {�.  $��68��6�   $��1��6�   $
��Left=�6�   $��10,0,0,0q�6�   �� 5_  &   -,   5        $��1��5_  -   $��1��6=   $��Remove��6J   $��Center=�6r   $��68��6�   $
��Left=�6�   $��10,0,0,0q�6�   ��5`  *   �� 5a  .   0 5b  2   �� 5c  6   1 5d     �� $ ListViewImages��$ SelectedIndex�2 -15e     .a�5f  :   �� 3 � {�4 .  6]   5g  7   5i  /   5k  '   5l  #   5m     5n     5o     5p     5q     5r     5s     5t     