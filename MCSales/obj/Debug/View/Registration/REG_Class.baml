   M S B A M L   `   `   `  ����B  >MCSales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MCSales.View.RegistrationMCSales.View.Registration  5   	   )    #MCSales.View.Registration.REG_Class   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   3local'clr-namespace:MCSales.View.Registration  5   	   -   5          �Name$  REG_Class_Screen��5   	    � Title$ Cadastrar Aula��5	   	   $	��368��6    $
��1024��6-    � Icon$. (/MCSales;component/Images/Icons/logo.png��6:    � 
ResizeMode$ NoResize=�6j    � WindowStartupLocation$ CenterScreen=�6�   ���	#FFD2D6DE � 	Resources 5         NoHover �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6    .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5"      � .+�5#   
   �� -   5         ��Name$ 	imgHeader��5#      $
��Left=�6#   $	��128��6>   $	��Top=�6K   $	��600��6c   $0��*/MCSales;component/Images/Icons/header.png��6o   $��	10,10,0,0q�6�   �� 5$   
   -   5         ��Name$ 
lblTeacher��5$      $��
Professor:��6$   $
��Left=�69   $	��Top=�6T   $��
34,168,0,0q�6l   $��14(�6�   $	��117��6�   �� 5%   
   -   5         ��Name$ 
cbxTeacher��5%      $
��Left=�6'   $	��Top=�6B   $	��213��6Z   $��163,174,0,0q�6f   6{   �� 5&   
   -   5        $ lblClassesCount��5&      $��Aulas na Semana:��6)   $
��Left=�6D   $	��Top=�6_   $��398,165,0,0q�6w   $��14(�6�   �� 5'   
   -   5        $ lblDate��5'      $��Dias na Semana:��6!   $
��Left=�6;   $	��Top=�6V   $��398,194,0,0q�6n   $��14(�6�   $	��117��6�   �� 5(   
   -   5        $ cbxDate��5(       �� SelectedValuePath$ Content��6$   $
��Left=�6@   $	��Top=�6[   $	��214��6s   $��526,200,0,0q�6    �� SelectedIndex$ 5��6�   .@�5)      �� -   5         ��Name$ _segunda��5)      $��Segunda��6-   6?   �� 5*      -	   5        $ _terca��5*      $��Terça��6+   6;   �� 5+      -
   5        $ _quarta��5+      $��Quarta��6,   6=   �� 5,      -   5        $ _quinta��5,      $��Quinta��6,   6=   �� 5-      -   5        $ _sexta��5-      $��Sexta��6+   6;   �� 5.      -   5        $ _sabado��5.      $��Sábado��6,   6=   �� 5/      -   5        $ _segundaQuarta��5/      $��Segunda e Quarta��63   $y�	Collapsed=�6N   6e   �� 50      -   5        $ _terçaQuinta��50      $��Terça e Quinta��61   $y�	Collapsed=�6J   6a   51      �� 52   
   -   5        $ lblClassDuration��52      $��Tempo por aula:��6*   $
��Left=�6D   $	��Top=�6_   $��
34,193,0,0q�6w   $��14(�6�   �� 53   
   -   5         ��Name$ btnRegisterClass��53      $��	Cadastrar��6+   $
��Left=�6?   $	��Top=�6Z   $	��135��6r   $��27��6~   
����������	#FF18A55D$��380,281,0,0q�6�   #��[  6�    � ToolTip$ Cadastrar aula.��6	  �� 54   
   -   5        $ 	btnCancel��54      $��Cancelar��6$   $
��Left=�67   $	��Top=�6R   $	��135��6j   $��27��6v   
����������	#FFA51818$��520,281,0,0q�6�   #��[  6�   $ Cancelar cadastro.��6�   �� 55   
   $
��Left=�6   $��89��6/   $��	0,106,0,0q�6;   $	��Top=�6N   $
��1018��6f   �� 56   
   $
��Left=�6   $��28��6/   $��	0,253,0,0q�6;   $	��Top=�6N   $
��1018��6f   %  Xceed.Wpf.Toolkit.IntegerUpDown  57   
   -   5          Name$ 	_numClass��57      $
��Left=�60   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 1X�6K   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X�6U      Maximum$ 2X�6c      Minimum$ 1X�6o   $	��Top=�6{   $	��214��6�   $��526,168,0,0q�6�   $
��Bold"�6�     58   
   -   5        $ _numDuration��58      $
��Left=�63   $ 1X�6N   $ 1X�6X   $ 2X�6f   $ 1X�6r   $	��Top=�6~   $	��211��6�   $��163,200,0,0q�6�   $
��Bold"�6�   �� 59   
   -   5        $ lblTime��59      $��	Horário:��6!   $
��Left=�64   $	��Top=�6O   $��746,194,0,0q�6g   $��14(�6|   $��76��6�   �� 5:   
   -   5        $ lblDaysOfWeek��5:      $��[Dias que tem aula]��6'   $��Center=�6E   $
��Left=�6i   $	��Top=�6�   $��827,155,0,0q�6�   $��14(�6�   $	��181��6�   ���	#FFA51818$
��Bold"�6�   �� 5;   
   -   5        $ cbxType��5;      $ Content��6$   $
��Left=�6@   $	��Top=�6[   $	��213��6s   $��163,225,0,0q�6   $ 5��6�   .@�5<      �� -   5        $ _ingles��5<      $��Inglês��6,   6=   �� 5=      -   5        $ _interativo��5=      $��
Interativo��60   6E   �� 5>      -   5        $ 	_hardware��5>      $��Hardware��6.   6A   �� 5?      -   5        $ _games��5?      $��Games��6+   6;   �� 5@      -   5        $ _informatica��5@      $��Informática��61   6G   �� 5A      -   5        $
 _adm��5A      $��Administração��6)   6A   5B      �� 5C   
   -   5        $ lblType��5C      $��Dias na Semana:��6!   $
��Left=�6;   $	��Top=�6V   $��
36,219,0,0q�6n   $��14(�6�   $	��117��6�   "  Xceed.Wpf.Toolkit.TimePicker  5D   
   -   5          Name$ _pickerStarts��5D      $��827,191,98,111q�6S   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 61   �� *CurrentDateTime+6S     5E   
   -    5        $ _pickerEnds��5E      $��920,191,10,111q�6Q    6/   �� *CurrentDateTime+6Q   5G      5H      