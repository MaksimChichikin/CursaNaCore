   M S B A M L   `   `   `  ����F  BCurcaNaCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CurcaNaCore.Views.AdminPageCurcaNaCore.Views.AdminPage  5      *    $CurcaNaCore.Views.AdminPage.TaskPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CurcaNaCore.Views.AdminPage     5        N� Title$  TaskPage��5	      .��5      � .+�5   
   � ���#e9e9e9 � RowDefinitions 5      �� 5      $	��77* �6    �� 5      $
��373* �6    .+�5      � $��0 0 0 0q�6   .+�5      �� $��2��6    �� Orientation$ 
Horizontal=�6.   .+�5      �� $��Bottom=�6!   $��0 50 0 0q�6=   $
��Left=�6Q   $ 
Horizontal=�6l   .+�5      �� -   5        $��	TxbSearch��5   m   $	��Top=�6"   $��20��6:   $	��330��6F   $
��Left=�6R      PlaceholderStyle#��[  6�   
 � Tag$ 
Поиск��6�   �� 5      -   5        $��
BtnRefresh��5   r   $��Right=�6!   $	��Top=�6=   $��5 0 10 0q�6U   $��20��6g   
������ .��5      �� $"��/Resource/Imagine/pngegg.png��6$   5      5      �� 5      $��40��6!   $	��200��6-   $	��Top=�6:   $
��Left=�6R   $�� -368 32 0 0q�6m   $ 
Horizontal=�6�   .+�5      �� $	��Top=�6    $��24��68   $&�� Количество задач:��6D   �� 5      -   5         ��Name$ LBlTask��5   8   $	��Top=�6    $��24��6J   5      5       �� 5!      -   5        $��BtnAdd��5!   �   $��15(�6   
������ $��0q�6@   $��30��6T   $	��150��6`   $�� 200 38 25 0q�6l   $#��Добавить задачу��6�   $��Right=�6�   $��Bottom=�6�   5"      &   System.Windows.Controls.DataGrid  5#      -   5        $��GridTask��5#   6      AutoGenerateColumns$ False��6   $��1��6F     DataGridStyle#��[ 6S      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 66   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   �� *Id+4  .System.Windows.Controls.DataGridComboBoxColumn  5&      $ Номер заказа��6-   -   5        
DGCBCOrder��$ * 5&   W   
   DisplayMemberPath$
 Id��5(         SelectedValuePath$ Id��5)         SelectedItemBinding 5'      �� *Order+   SelectedValueBinding 5*      �� *	IdOrder+  5+      $! Номер доставки��6-   -   5        DGCBCDelivery��$ * 5+   \   $
 Id��5-      $ Id��5.       5,      �� *
Delivery+ 5/      �� *
IdDelivery+  50      $= 7Количество товаров в доставке��6-   -   5        DGCBCValume��$ * 50   i   $
 Valume��52      $ Id��53       51      �� *
Delivery+ 54      �� *
IdDelivery+  55      $ Статус��6*   $ * 6:      
IsReadOnly$
 True��6�   	 6D   �� *.,IdDeliveryNavigation.IdStatusNavigation.Name+6�   4  .System.Windows.Controls.DataGridTemplateColumn  56      $  ��6-      CellTemplate 57      �� 58      .R�59   "   �� $ 
Horizontal=�6-   .+�5:   &   �� $��BtnEdit��6V   -	   5        $��20��5:   -   $��23��69   $��5 5 5 5 q�6D   
������ $��0q�6�   .��5;   *   �� $#��\Resource\Imagine\EditPng.png��60   $��15��6X   $��23��6d   5<   '   �� 5=   &   $��	BtnDelete��6W   -
   5        $��20��5=   -   $��23��69   $��5 5 5 5 q�6E   
������ $��0q�6�   .��5>   *   �� $%��\Resource\Imagine\DeletePng.png��60   $��15��6Z   $��23��6f   5?   '   5@   #   5A      5C      5E      5F      5G      5H      