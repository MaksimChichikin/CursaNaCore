   M S B A M L   `   `   `  ����F  BCurcaNaCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CurcaNaCore.Views.AdminPageCurcaNaCore.Views.AdminPage  5      .    (CurcaNaCore.Views.AdminPage.DeliveryPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CurcaNaCore.Views.AdminPage     5        N� Title$  DeliveryPage��5	      .��5
      � .+�5   
   � ���#e9e9e9 � RowDefinitions 5      �� 5      $	��77* �6    �� 5      $
��373* �6    .+�5      � $��0 0 0 0q�6   .+�5      �� $��2��6    �� Orientation$ 
Horizontal=�6.   .+�5      �� $��Bottom=�6!   $��0 50 0 0q�6=   $
��Left=�6Q   $ 
Horizontal=�6l   .+�5      �� -   5        $��	TxbSearch��5   m   $	��Top=�6"   $��20��6:   $	��330��6F   $
��Left=�6R      PlaceholderStyle#��[  6�   
 � Tag$ 
Поиск��6�   �� 5      -   5        $��
BtnRefresh��5   r   $��Right=�6!   $	��Top=�6=   $��5 0 10 0q�6U   $��20��6g   
������ .��5      �� $"��/Resource/Imagine/pngegg.png��6$   5      5      �� 5      $��40��6!   $	��200��6-   $	��Top=�6:   $
��Left=�6R   $�� -368 32 0 0q�6m   $ 
Horizontal=�6�   .+�5      �� $	��Top=�6    $��24��68   $,��&Количество доставок:��6D   �� 5      -   5         ��Name$ LBlDelivery��5   8   $	��Top=�6    $��24��6N   5      5      �� 5       -   5        $��BtnAdd��5    �   $��15(�6   
������ $��0q�6@   $��30��6T   $	��150��6`   $�� 200 38 25 0q�6l   $'��!Добавить доставку��6�   $��Right=�6�   $��Bottom=�6�   5!      &   System.Windows.Controls.DataGrid  5"      -   5        $��GridDelivery��5"   6      AutoGenerateColumns$ False��6   $��1��6J     DataGridStyle#��[ 6W      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 65   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6@   �� *Id+  5%      $' !Количество товара��6)   $	 150 6D   	 6P   �� *Valume+4  .System.Windows.Controls.DataGridComboBoxColumn  5&      $ Статус��6-   -   5        DGCBCStatus��$ * 5&   R   
   DisplayMemberPath$

 Name��5(         SelectedValuePath$ Id��5)         SelectedItemBinding 5'      �� *Status+   SelectedValueBinding 5*      �� *
IdStatus+4  .System.Windows.Controls.DataGridTemplateColumn  5,      $  ��6-      CellTemplate 5-      �� 5.      .R�5/   "   �� $ 
Horizontal=�6-   .+�50   &   �� $��BtnEdit��6V   -   5        $��20��50   -   $��23��69   $��5 5 5 5 q�6D   
������ $��0q�6�   .��51   *   �� $#��\Resource\Imagine\EditPng.png��60   $��15��6X   $��23��6d   52   '   �� 53   &   $��	BtnDelete��6W   -   5        $��20��53   -   $��23��69   $��5 5 5 5 q�6E   
������ $��0q�6�   .��54   *   �� $%��\Resource\Imagine\DeletePng.png��60   $��15��6Z   $��23��6f   55   '   56   #   57      59      5;      5<      5=      5>      