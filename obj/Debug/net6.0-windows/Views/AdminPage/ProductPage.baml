   M S B A M L   `   `   `  ����F  BCurcaNaCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CurcaNaCore.Views.AdminPageCurcaNaCore.Views.AdminPage  5      -    'CurcaNaCore.Views.AdminPage.ProductPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CurcaNaCore.Views.AdminPage     5        N� Title$  ProductPage��5	      .��5      � ���#e9e9e9 � RowDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��373* �6   .+�5   
   � $��0 0 0 0q�6   .+�5      �� $��2��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� $��Bottom=�6   $��0 50 0 0q�69   $
��Left=�6M   $ 
Horizontal=�6h   .+�5      �� -   5        $��	TxbSearch��5   i   $	��Top=�6   $��20��66   $	��330��6B   $
��Left=�6N      PlaceholderStyle#��[  6�   
 � Tag$ 
Поиск��6�   �� 5      -   5        $��Right=�5      $	��Top=�69   $��5 0 10 0q�6Q   $��20��6c   
������ .��5      �� $"��/Resource/Imagine/pngegg.png��6    5      5      �� 5      $��40��6   $	��200��6)   $	��Top=�66   $
��Left=�6N   $�� -368 32 0 0q�6i   $ 
Horizontal=�6   .+�5      �� $	��Top=�6   $��24��64   $*��$Количество товаров:��6@   �� 5      -   5         ��Name$ 
LBlProduct��5   4   $	��Top=�6   $��24��6I   5      5      �� 5       -   5        $��BtnAdd��5    �   $��15(�6   
������ $��0q�6<   $��30��6P   $	��150��6\   $�� 200 38 25 0q�6h   $!��Добавить товар��6~   $��Right=�6�   $��Bottom=�6�   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5        $��GridProduct��5"   2      AutoGenerateColumns$ False��6   $��1��6E     DataGridStyle#��[ 6R      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 62   	   
IsReadOnly$
	 True��6T   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� *Id+6T     5%      $# Название товара��6%   $ * 6>   
 6H   �� *NameOfProduct+4  .System.Windows.Controls.DataGridComboBoxColumn  5&      $ 
Бренд��6)   -   5        
DGCBCBrand��   DisplayMemberPath$ 	BrandName��5(         SelectedValuePath$ Id��5)         SelectedItemBinding 5'      �� *Brand+   SelectedValueBinding 5*      �� *	IdBrand+  5+      $' !Единица измерения��6)   -   5        	DGCBCUnit��$
 Name��5-      $ Id��5.       5,      �� *Unit+ 5/      �� *IdUnit+  50      $ Цена��6%   $ * 63   
 6=   �� *Price+4  .System.Windows.Controls.DataGridTemplateColumn  51      $  ��6)      CellTemplate 52      �� 53      .R�54      �� $ 
Horizontal=�6)   .+�55   "   �� $��BtnEdit��6R   -   5        $��20��55   )   $��23��65   $��5 5 5 5 q�6@   
������ $��0q�6�   .��56   &   �� $#��\Resource\Imagine\EditPng.png��6,   $��15��6T   $��23��6`   57   #   �� 58   "   $��	BtnDelete��6S   -	   5        $��20��58   )   $��23��65   $��5 5 5 5 q�6A   
������ $��0q�6�   .��59   &   �� $%��\Resource\Imagine\DeletePng.png��6,   $��15��6V   $��23��6b   5:   #   5;      5<      5>      5@      5A      5B      