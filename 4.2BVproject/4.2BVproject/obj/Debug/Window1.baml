   M S B A M L   `   `   `  ����G  C4.2BVproject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_4._2BVproject_4._2BVproject  5   	       _4._2BVproject.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_4._2BVproject     5   	     � Title$  Ugrožena vrsta��5   	   $	��430��6    $	��750��6-    � Icon$ images/slon.ico��5	   	    � 
ResizeMode$ CanMinimize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      ��  �� Padding$ 10q�6   ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��0.2* �6#   �� 5      $
��2.2* �6#   �� 5      $
��0.4* �6#   �� 5      $
��2.2* �6#   �� 5      $
��0.2* �6#   �� 5      $
��1.7* �6#   �� 5      $
��0.2* �6#   �� 5      $
��2.5* �6#   �� 5      $
��0.2* �6#    � RowDefinitions 5      �� 5      $
��0.1* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��2* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5       $��* �6    �� 5!      $
��1.3* �6    �� 5"      $
��1.5* �6    .+�5$      ��  � ToolTip$; 5Zvezdica (*) označava da je obavezno popuniti polje.��6   $��	10 15 0 0q�6W   $��1��6k   $��1��6{   $
��Left=�6�   $
��14px(�6�   
Oznaka*:6�   �� 5%      $; 5Zvezdica (*) označava da je obavezno popuniti polje.��6   $��	10 15 0 0q�6W   $��5��6k   $��1��6{   $
��Left=�6�   $
��14px(�6�   Ime*:6�   �� 5&      $��	10 10 0 0q�6   $��1��6,   $��2��6<   $
��Left=�6I   $
��14px(�6d   Opis:6{   �� 5'      $��	10 10 0 0q�6   $��5��6,   $��2��6<   $
��Left=�6I   $
��14px(�6d   Tip:6z   �� 5(      $��Center=�6   $��	10 0 0 20q�63   $��5��6G   $��7��6W   $
��Left=�6d   $
��14px(�6   Status ugroženosti:6�   �� 5)      $��Center=�6   $��10 0 0 0q�63   $��5��6F   $��3��6V   $
��Left=�6c   $
��14px(�6~   
Ikonica:6�   �� 5*      $��10 0 0 0q�6   $��1��6+   $��4��6;   $
��Left=�6H   $
��14px(�6c   Opasno po čoveka:6�   �� 5+      $��10 0 0 0q�6   $��5��6+   $��4��6;   $
��Left=�6H   $
��14px(�6c   Nalazi se na IUCN�� 6�   crvenoj listi:6�   �� 5,      $��10 0 0 0q�6   $��1��6+   $��5��6;   $
��Left=�6H   $
��14px(�6c   Živi u naseljenom�� 6�   
regionu:6�   �� 5-      $��10 5 0 0q�6   $��5��6+   $��5��6;   $
��Left=�6H   $
��14px(�6c   Turistički status:6�   �� 5.      $��10 0 0 0q�6   $��1��6+   $��6��6;   $
��Left=�6H   $
��14px(�6c   Godišnji prihod od�� 6�   
turizma:6�   �� 5/      $��10 0 0 0q�6   $��5��6+   $��6��6;   $
��Left=�6H   $
��14px(�6c   Datum otkrivanja:6�   �� 52      -   5        $��xOznaka��52   �    ^� ShowDuration$ 20000��6   $q kOvde unesite jedinstvenu oznaku ugrožene vrste.Neophodno je da se oznaka sastoji od najmanje 3 karaktera.��6;   $��0 15 0 0q�6�   $��3��6�   $��1��6�   $��Stretch=�6�   .��63  ��53      �� 54      	 �� Path$	 Oznaka�6   
 �� UpdateSourceTrigger$
 	LostFocus=�6,    �� ValidationRules 55      *   $_4._2BVproject.ValidacijaOznakeVrste  56      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6:   58      .��59        =� ErrorTemplate 5:      �� 5;      .R�5<      �� .+�5=      ��  �� Orientation$ 
Horizontal=�6)   $��0 0 20 0q�6B   .+�5>   "   �� 
���  ��$��20��6:   $��20��6E    �� CornerRadius$ 10��6Q    5?   )   �� $	 /ErrorContent�._�5@   &   �� $��!��60   $��center=�69   $��center=�6T   $
��Bold"�6q   
�������6�   5A   #   �� 5B   "   $��5,0,0,0q�6,   
���  ����6N   �� *[0].ErrorContent+5C      �� 5D      
���  ��$��1q�67   $	��5,0q�6K   $	��162��6X    6d   �� $	 /ErrorContent�._�5E   "   �� $��textBox��6<   5F      5G      5H      .��5I   ,   5J      �� 5M      -   5        $
��xIme��5M   f   $ 20000��6   $' !Ovde unesite ime ugrožene vrste.��6;   $��0 15 0 0q�6r   $��7��6�   $��1��6�   $
��Left=�6�   $	��180��6�   .��6�   ��5N      �� 5O      $		 Ime�6   $
 	LostFocus=�6)    5P      $   _4._2BVproject.ValidacijaVrste  5Q      $ RawProposedValue=�64   5S      .��5T        5U      �� 5V      .R�5W      �� .+�5X      �� $ 
Horizontal=�6)   $��0 0 20 0q�6B   .+�5Y   "   �� 
���  ��$��20��6:   $��20��6E   $ 10��6Q   ._�5Z   &   �� $��!��60   $��center=�69   $��center=�6T   $
��Bold"�6q   
�������6�   5[   #   �� 5\   "   $��5,0,0,0q�6,   
���  ����6N   �� *[0].ErrorContent+5]      �� 5^      
���  ��$��1q�67   $	��5,0q�6K   $	��180��6X   ._�5_   "   �� $��textBox��6<   5`      5a      5b      .��5c   ,   5d      �� 5g      $��3��6   $��2��6+   $��Stretch=�68   $��0 3 0 3q�6V   .��5h      �� -   5        $��xOpis��5h   k   $ 20000��6   $( "Ovde unesite opis ugrožene vrste.��6?    �� AcceptsReturn . 6�   5i      �� 5j      -   5        $	��tip��5j   �   $ 20000��6   $o iKada kliknete ovde otvoriće se padajuća listasa postojećim tipovima. Neophodno je da izaberete jedan.��6<   $��0 10 0 5q�6�   $	��180��6�   $��7��6�   $��2��6�   $
��Left=�6�   ��6  �� *TipoviVrsta+��5k      �� 5l      .R�5m      �� ��6$   �� *
ImeVrste+6@   5n      5p      �� 5r      -   5        $��xStatus��5r   �   $ 20000��6   $r lKada kliknete ovde otvoriće se padajuća lista.Potrebno je da izaberete kog statusa ugroženosti je vrsta.��6<   $��25��6�   $��Center=�6�   $��7��6�   $��7��6�   $��Stretch=�6  $��0 0 0 20q�6&  .@�5s      �� .��6   Kritično ugrožena62   �� 5t      .��6   	Ugrožena6)   �� 5u      .��6   	Ranjiva6(   �� 5v      .��6    Zavisna od očuvanja staništa6=   �� 5w      .��6   Blizu rizika6-   �� 5x      .��6   Najmanje rizika60   5y      � 5{      $��0 0 0 3q�6   $��7��6$   $��3��64   $��Stretch=�6A    5|      �� 5}      $��* �6'   �� 5~      $��* �6'   .+�5�      �� -   5        $��imgPhoto��5�   �   $ 20000��6   $y sOvo predstavlja podrazumevanu ikonicu tipa ugrožene vrste.Ukoliko želite da je promenite idite na dugme Odaberi.��6=   $��5q�6�   $
��Fill=�6�   $��0��6�   �� 5�      $��Center=�6   $��1��68   $
��Left=�6H   .+�5�      �� -   5        $��
btnOdaberi��5�   �   $ 20000��6   $� {Pritiskom na ovo dugme otvoriće se dijalog gde je potrebnoda izaberete ikonicu koju želite da dodelite ugroženoj vrsti.��6B   $��5 0 0 5q�6�   $��75��6�   .��6  
_Odaberi6  �� 5�      -   5        $��	btnOdbaci��5�   �   $ 20000��6   $Q KPritiskom na ovo dugme postaviće sepodrazumevana ikonica ugrožene vrste.��6B   $��5 0 0 5q�6�   $��75��6�   .��6�   	_Odbaci6�   5�      5�      �� 5�      -	   5        $��xOpasno��5�   �   $ 20000��6   $� �Potrebno je da izaberete li je ugrožena vrsta opasna po čoveka.Ukoliko jeste pritisnite kružić ispred Da, a ukoliko nije pritinite kružić ispred Ne.��6>   $ 
Horizontal=�6�   $��0 5 0 10q�6  $��3��6  $��4��6-  $��Stretch=�6:  .+�5�      	� -
   5         	�Name$ opasnoPoCovekaDA��5�      $��	20 0 40 0q�69   .��6L   Da6P   	� 5�      -   5        $ opasnoPoCovekaNE��5�      .��68   Ne6<   5�      �� 5�      $ 20000��6   $� �Potrebno je da izaberete li se ugrožena vrsta nalazi na najpoznatijoj svetskoj listi ugroženih vrsta.Ukoliko se nalazi na IUCN listi pritisnite kružić ispred Da, a ukoliko se ne nalazi na IUCN listi pritinite kružić ispred Ne.��6=   $ 
Horizontal=�60  $��0 5 0 10q�6I  $��7��6[  $��4��6k  $��Stretch=�6x  .+�5�      	� -   5        $ crvenoDA��5�      $��	20 0 40 0q�60   .��6C   Da6G   	� 5�      -   5        $ crvenoNE��5�      .��61   Ne65   5�      �� 5�      $ 20000��6   $� �Potrebno je da izaberete li ugrožena vrsta živi u naseljenom regionu.Ukoliko živi pritisnite kružić ispred Da, a ukoliko ne živi u naseljenom regionu pritinite kružić ispred Ne.��6>   $ 
Horizontal=�6   $��0 5 0 10q�6  $��3��6+  $��5��6;  $��Stretch=�6H  .+�5�      	� -   5        $ naseljenoDA��5�      $��	20 0 40 0q�63   .��6F   Da6J   	� 5�      -   5        $ naseljenoNE��5�      .��64   Ne68   5�      �� 5�      -   5        $��xTurista��5�   �   $ 20000��6   $| vKada kliknete ovde otvoriće se padajuća lista. Potrebnoje da izaberete kog turističkog statusa je ugrožena vrsta.��6<   $��0 5 0 10q�6�   $��7��6�   $��5��6�   $��Stretch=�6�   .@�5�      �� .��6   	Izolovana6*   �� 5�      .��6   Delimično habituirana66   �� 5�      .��6   Habituirana6,   5�      �� 5�      $��0 0 0 10q�6   $��3��6+   $��6��6;   .+�5�      �  5�      �� 5�      $��5* �6+   �� 5�      $
��2.5* �6+   .+�5�      �� -   5        $��	xGodisnje��5�   �   $ 20000��6   $= 7Ovde unesite koliko iznosi godišnji prihodod turizma.��6C   $��0��6�   $��Stretch=�6�   $��22��6�   $��Bottom=�6�   .��61  ��5�      �� 5�      $	 Prihod�6&   $
 	LostFocus=�64    5�   "   &    _4._2BVproject.ValidacijaPrihoda  5�   &   $ RawProposedValue=�6>   5�      .��5�   (    5�      �� 5�      .R�5�   "   �  5�   &   �� 5�   *   $��* �68   �� 5�   *   $��* �68    5�   &   �� 5�   *   .+�5�   &   �� $ 
Horizontal=�61   $��0 0 20 0q�6J   $��1��6\   .+�5�   *   �� 
���  ��$��20��6B   $��20��6M   $ 10��6Y    5�   )   �� $	 /ErrorContent�._�5�   .   �� $��!��68   $��center=�6A   $��center=�6\   $
��Bold"�6y   
�������6�   5�   +   �� 5�   *   $��5,0,0,0q�64   
���  ����6V   �� *[0].ErrorContent+5�   '   �� 5�   &   
���  ��$��1q�6?   $	��5,0q�6S   $	��162��6`   $��0��6�    6l   �� $	 /ErrorContent�._�5�   *   �� $��textBox��6D   5�   '   5�   #   5�      .��5�   4   5�      �� 5�      -   5        $��xValuta��5�   �   $ 20000��6   $| vKada kliknete ovde otvoriće se padajuća lista. Potrebnoje da izaberete valutu iznosa godišnjeg prihoda od turizma.��6D   $��1��6�    �� SelectedIndex$ 0��6�   .@�5�      �� .��6'   USD6,   �� 5�      .��6'   EUR6,   �� 5�      .��6'   RSD6,   5�      5�      5�      (  "System.Windows.Controls.DatePicker  5�      -   5        $��xDatum��5�   �   $ 20000��6   $� �Ovde možete uneti datum otkrivanja ugrožene vrste. Ukoliko pritisnetena ikonicu kalendara otvoriće se kalendar gde možete izabrati datum.��6>   $��7��6�   $��0 0 0 10q�6�   $��6��6	  $��Stretch=�6     SelectedDate$ 01/12/17X�64  �� 5�      -   5         ��Name$ PotvrdiDugme��5�     $ 20000��6    ^� ShowOnDisabled . $� �Kako bi dodavanje ugrožene vrste bilo moguće neophodno je da popunitesva polja sa zvezdicom (*). Pritiskom na dugme ugrožena vrsta će biti dodata.��6^   $��80��6  $��30��6"  $��Right=�6.  $��3��6J  $��8��6Z  .��6}  	Potvrdi6�  �� 5�      -   5        $; 5Pritiskom na dugme ugrožena vrsta neće biti dodata.��5�      $��5��6S   $��8��6c   $��80��6p   $��30��6{   $
��Left=�6�   .��6�   
Odustani6�   �� 5�      $��3��6   $��3��6)   $ Vertical=�66   .+�5�      �� $��Center=�6   Upotrebljene etikete6P   �� 5�      -   5         ��Name$ UpotrebljeneEtikete��5�   �   $ 20000��6   $? 9Ovde se nalaze etikete ugrožene vrste koje ste izabrali.��6@   $��Stretch=�6�   $��55��6�   ��6�   �� *IskorisceneEtikete+��5�      �� 5�      .R�5�      �� ��6(   �� *Oznaka+6B   5      5     5     �� 5     $��1��6   $��3��6)   $ Vertical=�66   .+�5     �� $��Center=�6   Slobodne etikete6L   �� 5     -   5        $ NeupotrebljeneEtikete��5  �   $ 20000��6   $G AOvde se nalaze etikete koje možete da dodelite ugroženoj vrsti.��6@   
�������$��2��6�   $��55��6�   ��6�   �� *NekorisceneEtikete+��5     �� 5	     .R�5
     �� ��6(   �� *Oznaka+6B   5     5     5     � 5     $��2��6   $��3��6#    5     �� 5     $��* �6$   61   �� 5     $��2* �6$   62   �� 5     $��2* �6$   62   .+�5     �� -   5        $ 	AddToUsed��5  �   $ 20000��6   $\ VPritiskom na strelicu će etiketa iz slobodnih etiketa preći u upotrebljene etikete.��6>   $��1��6�   ��6�   Z� ��6�   Z� .��5     �� $ 
Horizontal=�6!   .+�5     �� $��0��6    $��images/strelicadesno.jpg��6-   6Q   5     5     �� 5     -   5        $ AddToUnusedTags��5  �   $ 20000��6   $\ VPritiskom na strelicu će etiketa iz upotrebljenih etiketa preći u slobodne etikete.��6>   $��2��6�   ��6�   Z� ��6�   Z� .��5     �� $ 
Horizontal=�6!   .+�5     �� $��2��6    $��images/strelicalevo.jpg��6-   6P   5      5!     5"     5$     5%     5&     