   M S B A M L   `   `   `  ����B  >MCSales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MCSales.ViewMCSales.View  5   	       MCSales.View.ACTLogin   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   &localclr-namespace:MCSales.View  5   	   -   5          �Name$  LoginScreen��5   	    � Title$ Login��5	   	   $	��780��6   $
��1024��6$    � WindowStartupLocation$ CenterScreen=�61    � ToolTip$  ��6V    � Icon$. (/MCSales;component/Images/Icons/logo.png��6a   ���	#FFD2D6DE � 
ResizeMode$ NoResize=�6�    � WindowState$ 	Maximized=�6�    � WindowStyle$
 None=�6�    � 	Resources 5         NoHover	 �� 
TargetType
 �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	        �� 5   
   "	 ��6    .�5      �� 
 �@�OverridesDefaultStyle . 66   �� 5      
 �@�Cursor$
 Hand��6'   �� 5      
 � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver . . �5   "   �� 
 �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5#      (� .��5$   
   � $	��507��6   $
��1041��6   .+�5%      �� -   5         ��Name$ Canvas��5%      $
��Left=�6%   $	��380��6@   $	��Top=�6M   $	��676��6e   $��193,135,0,0q�6q   
�������.+�5&      %  Xceed.Wpf.Toolkit.MaskedTextBox  -   5          Name$ txtUser��5&   &   $��Center=�67      Mask$ Usuário��6Y   $
��Left=�6h   $��35��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��302��6�   $��18(�6�   ���	#FF646464$��1q�6  ���	#FF646464 �� Left$	 193��6.  
 �� Top$	 173��6@   �� SelectionBrush �	#FF18A55D$ Nome de usuário.��6�  ��6�   Z� 6�  G� 5'      -   5         G�Name$ psbPassword��5'      $��Center=�64   $
��Left=�6V   $	��Top=�6q   $	��302��6�   $��35��6�   $��20(�6�   $��1q�6�   ���	#FF646464$	 193��6�   $	 229��6  ���	#FF646464 G� SelectionBrush �	#FF18A55D$ Senha do usuário.��6�  ��6�   Z� 6�  �� 5(      -   5         ��Name$ btnLogin��5(      $��Login��6+   $
��Left=�6;   $	��Top=�6V   $��75��6n   $	 420��6y   $	 282��6�   $��24��6�   
����������	#FF18A55D#��[  6�   $ Realizar login.��6
  �� 5)      -   5         ��Name$ lblDesc��5)      $+��%Vagas disponíveis nos cursos Evolua.��6)   $
��Left=�6X   $	��Top=�6s   $	��371��6�   $��42��6�   ���	#FF666666$��22(�6�   $	 158��6�   $ 61��6�   �� 5*      -   5         ��Name$ imgLock��5*      $
��Left=�6)   $��20��6D   $	��Top=�6P   $��20��6h   $	 469��6s   $	 237��6�   $.��(/MCSales;component/Images/Icons/lock.png��6�   �� 5+      -   5        $ imgUser��5+      $
��Left=�6)   $��20��6D   $	��Top=�6P   $��20��6h   $	 469��6s   $	 180��6�   $.��(/MCSales;component/Images/Icons/user.png��6�   �� 5,      -	   5        $ 	btnCancel��5,      $��Cancelar��6,   $
��Left=�6?   $	��Top=�6Z   $��75��6r   $	 193��6}   $	 282��6�   $��24��6�   
����������	#FFA51818#��[  6�   $ Cancelar login.��6  5-      �� 5.      -
   5        $ 	imgHeader��5.      $
��Left=�6'   $	��128��6B   $	��Top=�6O   $	��600��6g   $��	231,2,0,0q�6s   $0��*/MCSales;component/Images/Icons/header.png��6�   (� 5/      $
��Left=�6   $	��100��61   $	��Top=�6>   $
��1008��6V   51      52      53      