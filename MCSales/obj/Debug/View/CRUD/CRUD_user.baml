   M S B A M L   `   `   `  ����B  >MCSales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MCSales.View.CRUDMCSales.View.CRUD  5   	   !    MCSales.View.CRUD.CRUD_user   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MCSales.View.CRUD     5   	   -   5          �Name$  user_crud_screen��5   	    � Title$ Controle de Usuários��5   	   $	��720��6&   $
��1280��63    � 
ResizeMode$ NoResize=�6@    � Icon$. (/MCSales;component/Images/Icons/logo.png��6V    � WindowStartupLocation$ CenterScreen=�6�   ���	#FFD2D6DE � 	Resources 5         NoHover �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6    .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5!      � .+�5"   
   �� -   5         ��Name$ 	imgHeader��5"      $
��Left=�6#   $	��128��6>   $	��Top=�6K   $	��600��6c   $0��*/MCSales;component/Images/Icons/header.png��6o   $��	10,10,0,0q�6�   &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ tblUser��5#      $
��Left=�6$   $	��Top=�6?   $	��376��6W   $
��1176��6d   $��
44,276,0,0q�6q   
�������   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      -   5        	ColumnCod��,  &System.Windows.Controls.DataGridColumn   Header$	 Cod��5%   8      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *
User_id.+  5&      -   5        
ColumnName��$
 Nome��5&   9   $ * 6H    6R   �� *	User_name+  5'      -   5        ColumnPermission��$ 
Permissão��5'   ?   $ * 6S    6]   �� *Permission_desc+5)      �� 5*   
   -   5         ��Name$ CanvasHeader��5*      $
��Left=�6'   $��77��6B   $	��Top=�6N   $
��1274��6f   $��	0,159,0,0q�6s   ���	#FF666666 J� Opacity$	 0.4Q�6�   �� 5+   
   -   5         ��Name$ btnRegisterUser��5+      $��	Cadastrar��6*   $
��Left=�6>   $	��Top=�6Y   $	��135��6q   $��40��6}   
����������	#FF18A55D$��
44,176,0,0q�6�   #��[  6�    � ToolTip$ Cadastrar novo usuário.��6  �� 5,   
   -	   5        $ btnViewUser��5,      $��
Visualizar��6&   $
��Left=�6;   $	��Top=�6V   $	��135��6n   $��40��6z   
����������	#FF18A55D$��184,176,0,0q�6�   #��[  6�   $&  Visualizar usuário selecionado.��6   �� 5-   
   -
   5        $ btnEditUser��5-      $��Editar��6&   $
��Left=�67   $	��Top=�6R   $	��135��6j   $��40��6v   
����������	#FF18A55D$��324,176,0,0q�6�   #��[  6�   $" Editar usuário selecionado.��6�   �� 5.   
   -   5        $ btnDeleteUser��5.      $��Excluir��6(   $
��Left=�6:   $	��Top=�6U   $	��135��6m   $��40��6y   
����������	#FF18A55D$��464,176,0,0q�6�   #��[  6�   $# Excluir usuário selecionado.��6  �� 5/   
   -   5         ��Name$ lblCount��5/      $��0��6"   $
��Left=�6.   $��1186,244,0,0q�6I   $	��Top=�6_   ���	#FF18A55D$��18(�6�   $��34��6�   �� 50   
   -   5        $ lblRegistersFound��50      $��Registros encontrados:��6+   $
��Left=�6L   $��1009,247,0,0q�6g   $	��Top=�6}   $��16(�6�   52      53      