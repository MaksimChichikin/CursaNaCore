   M S B A M L   `   `   `  ����F  BCurcaNaCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CurcaNaCore.Views.AdminPageCurcaNaCore.Views.AdminPage  5      -    'CurcaNaCore.Views.AdminPage.CompanyPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CurcaNaCore.Views.AdminPage     5        N� Title$  CompanyPage��5	      .��5      � ���#e9e9e9 � RowDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��373* �6   .+�5   
   � $��0 0 0 0q�6   .+�5      �� $��2��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� $��Bottom=�6   $��0 50 0 0q�69   $
��Left=�6M   $ 
Horizontal=�6h   .+�5      �� -   5        $��	TxbSearch��5   i   $	��Top=�6   $��20��66   $	��330��6B   $
��Left=�6N      PlaceholderStyle#��[  6�   
 � Tag$ 
Поиск��6�   �� 5      -   5        $��
BtnRefresh��5   n   $��Right=�6   $	��Top=�69   $��5 0 10 0q�6Q   $��20��6c   
������ .��5      �� $"��/Resource/Imagine/pngegg.png��6    5      5      �� 5      $��40��6   $	��200��6)   $	��Top=�66   $
��Left=�6N   $�� -368 32 0 0q�6i   $ 
Horizontal=�6   .+�5      �� $	��Top=�6   $��24��64   $,��&Количество компаний:��6@   �� 5      -   5         ��Name$ 
LBlCompany��5   4   $	��Top=�6   $��24��6I   5      5      �� 5       -   5        $��BtnAdd��5    �   $��15(�6   
������ $��0q�6<   $��30��6P   $	��150��6\   $�� 200 38 25 0q�6h   $'��!Добавить компанию��6~   $��Right=�6�   $��Bottom=�6�   5!      &   System.Windows.Controls.DataGrid  5"   
   -   5        $��GridCompany��5"   2      AutoGenerateColumns$ False��6   $��1��6E     DataGridStyle#��[ 6R      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 62   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   �� *Id+  5%      $ Компании��6%   $ * 67   	 6A   �� *CompanyName+  5&      $! Адрес компании��6%   $ * 6=   	 6G   �� *	Address+  5'      $! Номер компании��6%   $ * 6=   	 6G   �� *Phone+4  .System.Windows.Controls.DataGridTemplateColumn  5(      $  ��6)   
   CellTemplate
 5)      �� 5*      .R�5+      �� $ 
Horizontal=�6)   .+�5,   "   �� $��BtnEdit��6R   -   5        $��20��5,   )   $��23��65   $��5 5 5 5 q�6@   
������ $��0q�6�   .��5-   &   �� $#��\Resource\Imagine\EditPng.png��6,   $��15��6T   $��23��6`   5.   #   �� 5/   "   $��	BtnDelete��6S   -   5        $��20��5/   )   $��23��65   $��5 5 5 5 q�6A   
������ $��0q�6�   .��50   &   �� $%��\Resource\Imagine\DeletePng.png��6,   $��15��6V   $��23��6b   51   #   52      53      55      57      58      59      