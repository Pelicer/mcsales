   M S B A M L   `   `   `  ����B  >MCSales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:MCSales.View.RegistrationMCSales.View.Registration  5   	   (    "MCSales.View.Registration.REG_user   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:MCSales.View.Registration     5   	   -   5          �Name$  REG_User_Screen��5   	    � Title$ Cadastrar Usuário��5   	   $	��267��6#   $��384.5��60    � 
ResizeMode$ NoResize=�6>    � Icon$. (/MCSales;component/Images/Icons/logo.png��6T    � WindowStartupLocation$ CenterScreen=�6�   ���	#FFD2D6DA � 	Resources 5         NoHover �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6    .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5!      � .+�5"   
   �� -   5         ��Name$ 	imgHeader��5"      $
��Left=�6#   $��82��6>   $	��Top=�6J   $	��358��6b   $��	10,10,0,0q�6n   $0��*/MCSales;component/Images/Icons/header.png��6�   �� 5#   
   -   5         ��Name$ lblStaff��5#      $��Nome do Usuário:��6"   $
��Left=�6=   $	��Top=�6X   $��	10,97,0,0q�6p   �� 5$   
   -   5         ��Name$ txtUser��5$      $
��Left=�6#   $��23��6>    �� TextWrapping$
 Wrap=�6J   $	��Top=�6^   $	��246��6v   $��
122,97,0,0q�6�   $��1q�6�   ���	#FF18A55D6�   �� 5%   
   -   5        $ lblPassword��5%      $��Senha:��6%   $
��Left=�66   $	��Top=�6Q   $��
10,125,0,0q�6i   G� 5&   
   -   5         G�Name$ psbPassword��5&      $
��Left=�6+   $	��Top=�6F   $	��246��6^   $��122,125,0,0q�6j   ���	#FF18A55D$��1q�6�   $��23��6�   �� 5'   
   -   5        $ lblRole��5'      $��Permissão:��6!   $
��Left=�66   $	��Top=�6Q   $��
10,153,0,0q�6i   �� 5(   
   -   5         ��Name$ comboBox��5(      $
��Left=�6%   $	��Top=�6@   $	��246��6X   $��122,155,0,0q�6d   ���	#FF18A55D.@�5)      �� -	   5         ��Name$ _��5)      $�� ��6&   �� 5*      -
   5        $ Administrador��5*      $��Administrador��62   �� 5+      -   5        $ Administração��5+      $��Administração��62   �� 5,      -   5        $ Vendas��5,      $��Vendas��6+   �� 5-      -   5        $ 	Professor��5-      $��	Professor��6.   5.      �� 5/   
   -   5         ��Name$ btnRegisterUser��5/      $��	Cadastrar��6*   $��Center=�6>   $
��Left=�6b   $	��Top=�6}   $	��358��6�   $��31��6�   
����������	#FF18A55D$��
10,191,0,0q�6�   #��[  6	   � ToolTip$ Cadastrar usuário.��6*  51      52      