   M S B A M L   `   `   `  ����F  BCurcaNaCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CurcaNaCore.Views.AdminPageCurcaNaCore.Views.AdminPage  5      +    %CurcaNaCore.Views.AdminPage.OrderPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CurcaNaCore.Views.AdminPage     5        N� Title$  	OrderPage��5	      .��5      � .+�5   
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
Horizontal=�6�   .+�5      �� $	��Top=�6    $��24��68   $*��$Количество заказов:��6D   �� 5      -   5         ��Name$ LBlOrder��5   8   $	��Top=�6    $��24��6K   5      5       �� 5!      -   5        $��BtnAdd��5!   �   $��15(�6   
������ $��0q�6@   $��30��6T   $	��150��6`   $�� 200 38 25 0q�6l   $!��Добавить заказ��6�   $��Right=�6�   $��Bottom=�6�   5"      &   System.Windows.Controls.DataGrid  5#      -   5        $��	GridOrder��5#   5      AutoGenerateColumns$ False��6   $��1��6F     DataGridStyle#��[ 6S      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 66   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   �� *Id+4  .System.Windows.Controls.DataGridComboBoxColumn  5&      $ Компания��6-   -   5        DGCBCCompany��$ * 5&   U   
   DisplayMemberPath$
 CompanyName��5(         SelectedValuePath$ Id��5)         SelectedItemBinding 5'      �� *	Company+   SelectedValueBinding 5*      �� *	IdCompany+  5,      $ 
Товар��6-   -   5        DGCBCIdCatalog��$ * 5,   T   $
 NameOfProduct��5.      $ Id��5/       5-      �� *	Catalog+ 50      �� *	IdCatalog+  51      $ 
Бренд��6)   $ * 68      
IsReadOnly$
 True��6�   	 6B   �� *1/IdCatalogNavigation.IdBrandNavigation.BrandName+6�     52      $ Цена��6-   -   5        
DGCBCPrice��$ * 52   O   $
 True��6Y   $
 Price��54      $ Id��55       53      �� *	Catalog+ 56      �� *	IdCatalog+  57      $ Количество��6)   $ 90 6=   	 6H   �� *NumberOfGoods+  59      $ Дата заказа��6)   $ * 6>   	 6H   �� *	OrderDate+ �� StringFormat$ {0:dd.MM.yyyy}��  5:      $ Дата доставки��6)   $ * 6@   	 6J   �� *DeliveryDate+$ {0:dd.MM.yyyy}��4  .System.Windows.Controls.DataGridTemplateColumn  5;      $  ��6-      CellTemplate 5<      �� 5=      .R�5>   "   �� $ 
Horizontal=�6-   .+�5?   &   �� $��BtnEdit��6V   -	   5        $��20��5?   -   $��23��69   $��5 5 5 5 q�6D   
������ $��0q�6�   .��5@   *   �� $#��\Resource\Imagine\EditPng.png��60   $��15��6X   $��23��6d   5A   '   �� 5B   &   $��	BtnDelete��6W   -
   5        $��20��5B   -   $��23��69   $��5 5 5 5 q�6E   
������ $��0q�6�   .��5C   *   �� $%��\Resource\Imagine\DeletePng.png��60   $��15��6Z   $��23��6f   5D   '   5E   #   5F      5H      5J      5K      5L      5M      