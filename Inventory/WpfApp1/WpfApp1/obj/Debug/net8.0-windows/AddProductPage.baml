   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5          WpfApp1.AddProductPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp1     5        N� Title$  AddProductPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   .+�5   
   �� $ ��Add Product to Inventory !��6   $��32(�65   $��Center=�6C   $��Center=�6^   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��Center=�6X   .+�5      �� $��Product Name:��6   $��
0, 0, 0, 0q�6,   �� 5      -   5         ��Name$ ProductNameTB��5      $	��200��6-   $��15, 0, 0, 0q�69   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��Center=�6;   .+�5      �� $��Product Definition:��6   $��
0, 0, 0, 0q�62   �� 5      -   5        $ ProductDefinitionTB��5      $	��200��63   5      �� 5   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��Center=�6X   .+�5      �� $��Product Price:��6   $��
0, 0, 0, 0q�6-   �� 5       -   5        $ ProductPriceTB��5       $	��200��6.   $��15, 0, 0, 0q�6:   5!      �� 5"   
   $ 
Horizontal=�6   $��4��6.   $��Center=�6;   $��Center=�6X   .+�5#      �� $��Product Amount:��6   $��
0, 0, 0, 0q�6.   �� 5$      -   5        $ ProductAmountTB��5$      $	��200��6/   $��15, 0, 0, 0q�6;   5%      �� 5&   
   $ 
Horizontal=�6   $��5��6.   $��Center=�6;   $��Bottom=�6X   $��0, 0, 0, 10q�6s   .+�5'      �� -   5         ��Name$ AddProductBtn��5'      $��Add Product��6,   $��0, 0, 50, 0q�6B   $	��100��6W   6c   �� 5(      -   5        $ CancelProductBtn��5(      $��Cancel��6/   $	��100��6@   6L   5)      5*      5+      