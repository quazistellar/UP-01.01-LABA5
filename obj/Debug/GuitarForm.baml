   M S B A M L   `   `   `  ����J  FUP_01.01.Laba_5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:UP_01._01.Laba_5UP_01._01.Laba_5  5      !    UP_01._01.Laba_5.GuitarForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:UP_01._01.Laba_5     5      -   5          N� Title$  
GuitarForm��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��300 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ container_pages��5      $��0��6,   $��0��6<      
IsReadOnly . ���	#FFFEBDB4���	#FFE200FF$��Arial Black)�6�   $��14(�6�   � 5   
   $��0��6   $��1��6    5      �� 5      $	��298 �6#    � RowDefinitions 5      �� 5      $��30 �6    �� 5      $��40 �6    �� 5       $��60 �6    �� 5!      $��50 �6    �� 5"      $��26 �6    �� 5#      $	��205 �6    .+�5'      �� -   5         ��Name$ message��5'      $��3��6)   $��1��66   ���	#FFEE8E8E6F   �� 5(      -   5        $
 txt1��5(      $��0��6&   $��1��63   $.��(Данные для заполнения��6C   ���	#FFEE8E8E$��Arial Black)�6w    �� TextAlignment$ Center=�6�   �� 5)      -   5        $
 txt2��5)      $��1��6&   $��1��63   $=��7Введите название формы гитары��6C   ���	#FFFFBAF6$��Arial Black)�6   �� 5*      -   5         ��Name$ write1��5*      $��2��6&   $��1��63    �� TextWrapping$
 Wrap=�6C   	 �� SelectionBrush	 �	#FFFF00FC
���   �6r   � 5.      $��4��6   $��1��6     5/      �� 50      �� 51      �� 52      �� 53      .+�56      �� -   5        
 ��Name$
 	add_admin��56      $��Добавить��6,   $��4��6?   
���   ����	#FFF14D4D$��Arial Black)�6w   $��1��6�   �� 57      -   5        $
 
edit_admin��57      $��Изменить��6-   
���   ����	#FFFF7171$��Arial Black)�6k   6�   �� 58      -	   5        $
 delete_admin��58      $��Удалить��6/   $��2��6A   
���   ����	#FFE63434$��Arial Black)�6|   6�   �� 59      -
   5        $
 import��59      $��Импорт��6)   $��3��6:   
���   ����	#FFE63434$��Arial Black)�6u   6�   5:      5<      5?      5@      