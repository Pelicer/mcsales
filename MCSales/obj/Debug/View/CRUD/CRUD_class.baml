   M S B A M L   `   `   `  ����B  >MCSales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MCSales.View.CRUDMCSales.View.CRUD  5   	   "    MCSales.View.CRUD.CRUD_class   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:MCSales.View.CRUD     5   	     � Title$  Controle de Aulas��5   	   $	��720��6#   $
��1280��60    � 
ResizeMode$ NoResize=�6=    � Icon$. (/MCSales;component/Images/Icons/logo.png��6S    � WindowStartupLocation$ CenterScreen=�6�   ���	#FFD2D6DE � 	Resources 5         NoHover �� 
TargetType �� Property �� Value �� 
TargetType	 �� Triggers
 P� Property P� Value��%�  &	        �� 5   
   " ��6    .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      	 5      P� 5      
 �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5!      � .+�5"   
   �� -   5         ��Name$ 	imgHeader��5"      $
��Left=�6#   $	��128��6>   $	��Top=�6K   $	��600��6c   $0��*/MCSales;component/Images/Icons/header.png��6o   $��	10,10,0,0q�6�   &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ tblClass��5#      $
��Left=�6%   $	��Top=�6@   $	��376��6X   $
��1176��6e   $��
44,276,0,0q�6r   
�������   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      -   5        	ColumnCod��,  &System.Windows.Controls.DataGridColumn   Header$
 Cod.��5%   8      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6R   �� *	Class_id.+  5&      -   5        ColumnTeacher��$ 	Professor��5&   <   $ * 6P    6Z   �� *Teacher_name+  5'      -   5        
ColumnType��$ Matéria��5'   9   $ * 6K    6U   �� *Type+  5(      -   5        ColumnClassTime��$ Horário de Aula��5(   >   $ * 6X    6b   �� *Class_TotalHours+  5)      -   5        ColumnClassDay��$ Dia da semana��5)   =   $ * 6U    6_   �� *	Class_day+  5*      -   5        ColumnVacancyCount��$ N° de Vagas��5*   A   $ * 6W      
Foreground
 �  �� 6a   �� *Class_vacancys+6�   5,      �� 5-   
   -	   5         ��Name$ CanvasHeader��5-      $
��Left=�6'   $��77��6B   $	��Top=�6N   $
��1274��6f   $��	0,159,0,0q�6s   ���	#FF666666 J� Opacity$	 0.4Q�6�   �� 5.   
   -
   5         ��Name$ btnRegisterClass��5.      $��	Cadastrar��6+   $
��Left=�6?   $	��Top=�6Z   $	��135��6r   $��40��6~   
����������	#FF18A55D$��
44,176,0,0q�6�   #��[  6�    � ToolTip$ Cadastrar nova aula.��6  �� 5/   
   -   5        $ btnViewClass��5/      $��
Visualizar��6'   $
��Left=�6<   $	��Top=�6W   $	��135��6o   $��40��6{   
����������	#FF18A55D$��184,176,0,0q�6�   #��[  6�   $" Visualizar aula selecionada.��6�   6  �� 50   
   -   5        $ btnEditClass��50      $��Editar��6'   $
��Left=�68   $	��Top=�6S   $	��135��6k   $��40��6w   
����������	#FF18A55D$��324,176,0,0q�6�   #��[  6�   $ Editar aula selecionada.��6�   6  �� 51   
   -   5        $ btnDeleteClass��51      $��Excluir��6)   $
��Left=�6;   $	��Top=�6V   $	��135��6n   $��40��6z   
����������	#FF18A55D$��464,176,0,0q�6�   #��[  6�   $ Excluir aula selecionada.��6�   6
  �� 52   
   -   5         ��Name$ lblCount��52      $��0��6"   $
��Left=�6.   $��1186,244,0,0q�6I   $	��Top=�6_   ���	#FF18A55D$��18(�6�   $��34��6�   �� 53   
   -   5        $ lblRegistersFound��53      $��Registros encontrados:��6+   $
��Left=�6L   $��1009,247,0,0q�6g   $	��Top=�6}   $��16(�6�   55      56      