   M S B A M L   `   `   `  ����G  C4.2BVproject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_4._2BVproject_4._2BVproject  5   	       _4._2BVproject.Window3   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_4._2BVproject     5   	     � Title$  Etiketa ugrožene vrste��5   	   $	��270��6(   $	��400��65    � Icon$ images/slon.ico��5	   	    � 
ResizeMode$ CanMinimize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      ��  �� Padding$ 10q�6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��0.2* �6#   �� 5      $
��1.8* �6#   �� 5      $
��0.2* �6#   �� 5      $
��2.2* �6#   �� 5      $
��0.2* �6#    � RowDefinitions 5      �� 5      $��10 �6    �� 5      $
��0.2* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $
��2.5* �6    �� 5      $
��1.1* �6    .+�5      ��  � ToolTip$; 5Zvezdica (*) označava da je obavezno popuniti polje.��6   $��10 0 0 0q�6W   $��1��6j   $��2��6z   $
��Left=�6�   $
��14px(�6�   
Oznaka*:6�   �� 5      $��10 0 0 0q�6   $��1��6+   $��3��6;   $
��Left=�6H   $
��14px(�6c   Boja:6z   �� 5      $��10 0 0 0q�6   $��1��6+   $��4��6;   $
��Left=�6H   $
��14px(�6c   Opis:6z   �� 5!      -   5        $��xOznaka��5!   �    ^� ShowDuration$ 20000��6   $y sOvde unesite jedinstvenu oznaku etikete ugrožene vrste.Neophodno je da se oznaka sastoji od najmanje 3 karaktera.��6<   $��0 0 0 6q�6�   $��3��6�   $��2��6�   $��Stretch=�6�   .��6;  ��5"      �� 5#      	 �� Path$	 Oznaka�6   
 �� UpdateSourceTrigger$
 	LostFocus=�6,    �� ValidationRules 5$      ,   &_4._2BVproject.ValidacijaOznakeEtikete  5%      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6<   5'      .��5(        =� ErrorTemplate 5)      �� 5*      .R�5+      �� .+�5,      ��  �� Orientation$ 
Horizontal=�6)   $��0 0 20 0q�6B   .+�5-   "   �� 
���  ��$��20��6:   $��20��6E    �� CornerRadius$ 10��6Q    5.   )   �� $	 /ErrorContent�._�5/   &   �� $��!��60   $��center=�69   $��center=�6T   $
��Bold"�6q   
�������6�   50   #   �� 51   "   $��5,0,0,0q�6,   
���  ����6N   �� *[0].ErrorContent+52      �� 53      
���  ��$��1q�67   $	��5,0q�6K   $	��174��6X    6d   �� $	 /ErrorContent�._�54   "   �� $��textBox��6<   55      56      57      .��58   ,   59      �� 5:      -   5        $��xBoja��5:   �   $ 20000��6   $} wKada kliknete ovde otvoriće se padajuća lista sa postojećim bojama.Potrebno je da izaberete jednu boju za etiketu. ��6=   $��0 0 0 6q�6�   $��3��6�   $��3��6�   $��Stretch=�6�   .@�5;      �� .��6   Crna6%   �� 5<      .��6   Žuta6%   �� 5=      .��6   Narandžasta6,   �� 5>      .��6   Zelena6'   �� 5?      .��6   Plava6&   �� 5@      .��6   Ljubičasta6+   �� 5A      .��6   Bela6%   5B      �� 5C      $��0 0 0 3q�6   $��3��6,   $��4��6<   $��Stretch=�6I   .��5D      �� -   5        $��xOpis��5D   t   $ 20000��6   $0 *Ovde unesite opis etikete ugrožene vrste.��6@    �� AcceptsReturn . 6�   5E      �� 5F      -   5         ��Name$ PotvrdiDugme��5F   A  $ 20000��6    ^� ShowOnDisabled . $� �Kako bi dodavanje etikete ugrožene vrste bilo moguće neophodno je da popunitepolje sa zvezdicom (*). Pritiskom na dugme etiketa ugrožene vrste će biti dodata.��6^   $��30��6  $��80��6  $��Right=�6$  $��1��6W  $��5��6g  .��6�  	Potvrdi6�  �� 5G      -   5        $ 20000��5G      $C =Pritiskom na dugme etiketa ugrožene vrste neće biti dodata.��69   $��3��6�   $��5��6�   $��80��6�   $��30��6�   $
��Left=�6�   .��6�   
Odustani6�   5H      5I      5J      