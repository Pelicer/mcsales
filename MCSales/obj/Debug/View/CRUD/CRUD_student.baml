   M S B A M L   `   `   `  ����B  >MCSales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MCSales.View.CRUDMCSales.View.CRUD  5   	   $    MCSales.View.CRUD.CRUD_student   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MCSales.View.CRUD     5   	   -   5          �Name$	  sss��5   	    � Title$ Controle de Alunos��5   	   $	��720��6$   $
��1280��61    � Icon$. (/MCSales;component/Images/Icons/logo.png��6>    � 
ResizeMode$ NoResize=�6n    � WindowStartupLocation$ CenterScreen=�6�   ���	#FFD2D6DE � 	Resources 5         NoHover �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6    .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5!      � .+�5"   
   �� -   5         ��Name$ 	imgHeader��5"      $
��Left=�6#   $	��128��6>   $	��Top=�6K   $	��600��6c   $0��*/MCSales;component/Images/Icons/header.png��6o   $��	10,10,0,0q�6�   &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ tblStudents��5#      $
��Left=�6(   $	��Top=�6C   $	��376��6[   $
��1176��6h   $��
44,276,0,0q�6u   
�������   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      -   5        	ColumnCod��,  &System.Windows.Controls.DataGridColumn   Header$	 CTR��5%   8      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *Student_ctr.+  5&      -   5        
ColumnName��$
 Nome��5&   9   $ * 6H    6R   �� *Student_name+  5'      -   5        ColumnSubscribeDay��$ Data de Inscrição��5'   A   $ * 6]    6g   �� *Student_subscriptionDate+  5(      -   5        ColumnClassDay��$ 	COD. Aula��5(   =   $ * 6Q    6[   �� *
Class_id+5*      �� 5+   
   -   5         ��Name$ CanvasHeader��5+      $
��Left=�6'   $��77��6B   $	��Top=�6N   $
��1274��6f   $��	0,159,0,0q�6s   ���	#FF666666 J� Opacity$	 0.4Q�6�   �� 5,   
   -	   5         ��Name$ btnRegisterStudent��5,      $��	Cadastrar��6-   $
��Left=�6A   $	��Top=�6\   $	��135��6t   $��40��6�   
����������	#FF18A55D$��
44,176,0,0q�6�   #��[  6�    � ToolTip$ Cadastrar novo aluno.��6  �� 5-   
   -
   5        $ btnViewStudent��5-      $��
Visualizar��6)   $
��Left=�6>   $	��Top=�6Y   $	��135��6q   $��40��6}   
����������	#FF18A55D$��184,176,0,0q�6�   #��[  6�   $# Visualizar aluno selecionado.��6  �� 5.   
   -   5        $ btnEditStudent��5.      $��Editar��6)   $
��Left=�6:   $	��Top=�6U   $	��135��6m   $��40��6y   
����������	#FF18A55D$��324,176,0,0q�6�   #��[  6�   $ Editar aluno selecionado.��6  �� 5/   
   -   5        $ btnDeleteStudent��5/      $��Excluir��6+   $
��Left=�6=   $	��Top=�6X   $	��135��6p   $��40��6|   
����������	#FF18A55D$��464,176,0,0q�6�   #��[  6�   $  Excluir aluno selecionado.��6  �� 50   
   -   5         ��Name$ lblCount��50      $��0��6"   $
��Left=�6.   $��1186,244,0,0q�6I   $	��Top=�6_   ���	#FF18A55D$��18(�6�   $��34��6�   �� 51   
   -   5        $ lblRegistersFound��51      $��Registros encontrados:��6+   $
��Left=�6L   $��1009,247,0,0q�6g   $	��Top=�6}   $��16(�6�   53      54      