   M S B A M L   `   `   `  ����F  BCurcaNaCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:CurcaNaCore.Views.AdminPageCurcaNaCore.Views.AdminPage  5      *    $CurcaNaCore.Views.AdminPage.UserPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:CurcaNaCore.Views.AdminPage     5        N� Title$  UserPage��5	      .��5
      � ���#e9e9e9 � RowDefinitions 5   
   �� 5      $	��77* �6   �� 5      $
��373* �6   .+�5   
   � $��0 0 0 0q�6   .+�5      �� $��2��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� $��Bottom=�6   $��0 50 0 0q�69   $
��Left=�6M   $ 
Horizontal=�6h   .+�5      �� -   5        $��	TxbSearch��5   i   $	��Top=�6   $��20��66   $	��330��6B   $
��Left=�6N      PlaceholderStyle#��[  6�   
 � Tag$ 
Поиск��6�   �� 5      -   5        $��
BtnRefresh��5   n   $��Right=�6   $	��Top=�69   $��5 0 10 0q�6Q   $��20��6c   
������ .��5      �� $"��/Resource/Imagine/pngegg.png��6    5      5      5      �� 5      -   5        $��BtnAdd��5   �   $��15(�6   
������ $��0q�6<   $��30��6P   $	��150��6\   $�� 200 50 25 0q�6h   $!��Добавить юзера��6~   $��Right=�6�   $��Bottom=�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��	GridBrand��5   2      AutoGenerateColumns$ False��6   $��1��6C     DataGridStyle#��[ 6P      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+  5!      $ 
Логин��6%   $ * 64    6>   �� *Login+  5"      $ Пароль��6%   $ * 65    6?   �� *
Password+4  .System.Windows.Controls.DataGridComboBoxColumn  5#      $ Роль��6)   -   5        	DGCBCRole��$ * 5#   J   	   DisplayMemberPath$
	 Name��5%      
   SelectedValuePath$
 Id��5&         SelectedItemBinding 5$      �� *Role+   SelectedValueBinding 5'      �� *IdRole+  5(      $ Активность��6%   $ * 69    6C   �� *IdUserActivityNavigation.Name+  5)      $ Статус��6)   -   5        DGCBCUserStatus��$ * 5)   R   $
	 Name��5+      $
 Id��5,       5*      �� *
UserStatus+ 5-      �� *IdUserStatus+  5.      $ Дата создания��6%   $ * 6<      
IsReadOnly$
 True��6b    6F   �� *	DateAdd+6b     5/      $ ФИО��6%   $ * 62   $
 True��6Y    6<   �� *
FullName+6Y   4  .System.Windows.Controls.DataGridTemplateColumn  50      $  ��6)      CellTemplate 51      �� 52      .R�53      �� $ 
Horizontal=�6)   .+�54   "   �� $��BtnEdit��6R   -   5        $��20��54   )   $��23��65   $��5 5 5 5 q�6@   
������ $��0q�6�   .��55   &   �� $#��\Resource\Imagine\EditPng.png��6,   $��15��6T   $��23��6`   56   #   �� 57   "   $��	BtnDelete��6S   -   5        $��20��57   )   $��23��65   $��5 5 5 5 q�6A   
������ $��0q�6�   .��58   &   �� $%��\Resource\Imagine\DeletePng.png��6,   $��15��6V   $��23��6b   59   #   5:      5;      5=      5?      5@      5A      