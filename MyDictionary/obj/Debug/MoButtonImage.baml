   M S B A M L   `   `   `  ����G  CMyDictionary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MyDictionaryMyDictionary  5           MyDictionary.MoButtonImage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:MyDictionary     5      .��5
      �� -   5        $��borMain��5      $��0��5
         MoButtonImageBorderStyle#��[  5      '  !System.Windows.VisualStateManager    VisualStateGroups  5   
   %  System.Windows.VisualStateGroup  5         Name$ MouseStates��6      States. 5         System.Windows.VisualState     Name$ 
MouseEnter��6      
Storyboard. 5      �� .��5      U�  �� 
TargetName$ borMain��5       �� TargetProperty$ Width�5      .\�5      ��  O� KeyTime$ 
00:00:0.01��63    O� Value$ 72Q�6H   5      5      5        5      $ 
MouseLeave��6   5      ._�5   
   ��   pdsaButtonImageImageStyle#��[ 6   y�5      �� 	 �� Path$	 
Visibility���5       �� $	 ImageUri�
 � ToolTip
 5!      �� $	 ToolTip�5"      5#      