   M S B A M L   `   `   `  ����G  C4.2BVproject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_4._2BVproject_4._2BVproject  5   	       _4._2BVproject.Window2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_4._2BVproject     5   	     � Title$  Tip ugrožene vrste��5   	   $	��320��6$   $	��430��61    � Icon$ images/slon.ico��5	   	    � 
ResizeMode$ CanMinimize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ local:MyCommands.ExitDemo��5      6}   .��5      ��  �� Padding$ 10q�6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��0.2* �6#   �� 5      $
��2.2* �6#   �� 5      $
��0.2* �6#   �� 5      $
��2.2* �6#   �� 5      $
��0.2* �6#    � RowDefinitions 5      �� 5      $��10 �6    �� 5      $
��0.2* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��2* �6    �� 5      $
��1.5* �6    �� 5      $��1* �6    .+�5!      �� 	 � ToolTip$;	 5Zvezdica (*) označava da je obavezno popuniti polje.��6   $��10 0 0 0q�6W   $��1��6j   $��2��6z   $
��Left=�6�   $
��14px(�6�   
Oznaka*:6�   �� 5"      $;	 5Zvezdica (*) označava da je obavezno popuniti polje.��6   $��10 0 0 0q�6W   $��1��6j   $��3��6z   $
��Left=�6�   $
��14px(�6�   Ime*:6�   �� 5#      $��10 0 0 0q�6   $��1��6+   $��4��6;   $
��Left=�6H   $
��14px(�6c   
Ikonica:6}   �� 5$      $��10 0 0 0q�6   $��1��6+   $��5��6;   $
��Left=�6H   $
��14px(�6c   Opis:6z   �� 5'      -   5        $��xOznaka��5'   �   
 ^� ShowDuration$
 20000��6   $v	 pOvde unesite jedinstvenu oznaku tipa ugrožene vrste.Neophodno je da se oznaka sastoji od najmanje 3 karaktera.��6:   $��0 0 0 13q�6�   $��3��6�   $��2��6�   $��Stretch=�6�   .��67  ��5(      �� 5)       �� Path$ Oznaka�6    �� UpdateSourceTrigger$ 	LostFocus=�6,    �� ValidationRules 5*      )   #_4._2BVproject.ValidacijaOznakeTipa  5+      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�69   5-      .��5.        =� ErrorTemplate 5/      �� 50      .R�51      �� .+�52      ��  �� Orientation$ 
Horizontal=�6)   $��0 0 20 0q�6B   .+�53   "   �� 
���  ��$��20��6:   $��20��6E    �� CornerRadius$ 10��6Q   	 54   )   �� $ /ErrorContent�._�55   &   �� $��!��60   $��center=�69   $��center=�6T   $
��Bold"�6q   
�������6�   56   #   �� 57   "   $��5,0,0,0q�6,   
���  ����6N   �� *[0].ErrorContent+58      �� 59      
���  ��$��1q�67   $	��5,0q�6K   $	��174��6X   	 6d   �� $ /ErrorContent�._�5:   "   �� $��textBox��6<   5;      5<      5=      .��5>   ,   5?      �� 5B      -   5        $
��xIme��5B   �   $
 20000��6   $d	 ^Ovde unesite ime tipa ugrožene vrste.Neophodno je da se ime sastoji od najmanje 3 karaktera.��6:   $��0 3 0 10q�6�   $��3��6�   $��3��6�   $��Stretch=�6�   .��6  ��5C      �� 5D      $	 Ime�6   $ 	LostFocus=�6)    5E      $   _4._2BVproject.ValidacijaVrste  5F      $ RawProposedValue=�64   5H      .��5I        5J      �� 5K      .R�5L      �� .+�5M      �� $ 
Horizontal=�6)   $��0 0 20 0q�6B   .+�5N   "   �� 
���  ��$��20��6:   $��20��6E   $ 10��6Q   	 5O   )   ��  �� ElementName$	 Ime��$- 'Ime.(Validation.Errors)[0].ErrorContent�._�5P   &   �� $��!��60   $��center=�69   $��center=�6T   $
��Bold"�6q   
�������6�   5Q   #   �� 5R   "   $��5,5,0,0q�6,   
���  ����6N   �� *[0].ErrorContent+5S      �� 5T      
���  ��$��1q�67   $	��5,0q�6K   $	��174��6X   ._�5U   "   �� $��textBox��6<   5V      5W      5X      .��5Y   ,   5\      � 5`      $��0 0 0 3q�6   $��3��6$   $��4��64   $��Stretch=�6A    5a      �� 5b      $��* �6'   �� 5c      $��* �6'   .+�5f      �� -   5        $��imgPhoto��5f   �   $
 20000��6   $y	 sOvo predstavlja podrazumevanu ikonicu tipa ugrožene vrste.Ukoliko želite da je promenite idite na dugme Odaberi.��6<   $��5q�6�   $
��Fill=�6�   $��0��6�   �� 5g      $��1��6   $
��Left=�6.   $��	10 0 0 20q�6I   $��Bottom=�6\   .+�5h      �� -   5        $��
btnOdaberi��5h   �   $
 20000��6   $�	 Pritiskom na ovo dugme otvoriće se dijalog gde je potrebnoda izaberete ikonicu koju želite da dodelite tipu ugrožene vrste.��6A   $��0 0 0 5q�6�   $��75��6�   .��6  
_Odaberi6  �� 5i      -   5        $��	btnOdbaci��5i   �   $
 20000��6   $V	 PPritiskom na ovo dugme postaviće sepodrazumevana ikonica tipa ugrožene vrste.��6A   $��75��6�   .��6�   	_Odbaci6�   5j      5k      �� 5l      -   5        $��xOpisScroll��5l   g   $��0 0 0 3q�6   $��3��6,   $��5��6<   $��Stretch=�6I   .��5m      �� -   5        $��xOpis��5m   o   $
 20000��6   $-	 'Ovde unesite opis tipa ugrožene vrste.��6>    �� AcceptsReturn . 6�   5n      �� 5o      -	   5         ��Name$ PotvrdiDugme��5o   �    ^� ShowOnDisabled . $�	 �Kako bi dodavanje tipa ugrožene vrste bilo moguće neophodno je da popunitesva polja sa zvezdicom (*). Pritiskom na dugme tip ugrožene vrste će biti dodat.��6:   $��1��6�   $��6��6  $��80��6  $��30��6#  $��Right=�6/  .��6a  	Potvrdi6j  �� 5p      -
   5        $ 	xOdustani��5p   9   $
 20000��6   $>	 8Pritiskom na dugme tip ugrožene vrste neće biti dodat.��6L   $��3��6�   $��6��6�   $��80��6�   $��30��6�   $
��Left=�6�   .��6�   
Odustani6�   5s      5u      5v      