   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WpfApp.Views.TicketViewsWpfApp.Views.TicketViews  5   	   )    #WpfApp.Views.TicketViews.TicketMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:WpfApp.Views.TicketViews     5   	     � Title$  
TicketMenu��5   	   $
��Auto��6   $
��Auto��6*   .��5	      � .+�5
   
   �� -   5        $��Create��5
      $
��Left=�6"   $��	43,85,0,0q�6=   $	��Top=�6P   $��75��6h   6s   �� 5   
   -   5        $��Delete��5      $
��Left=�6"   $��
43,179,0,0q�6=   $	��Top=�6Q   $��75��6i   6t   �� 5   
   -   5        $��Update��5      $
��Left=�6"   $��
43,132,0,0q�6=   $	��Top=�6Q   $��75��6i   6t   �� 5   
   -   5        $
��Back��5      $
��Left=�6    $��
43,432,0,0q�6;   $��75��6O   $��22��6Z   $	��Top=�6f    J� RenderTransformOrigin$ 0.519,-0.754&�6~   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg��5         AutoGenerateColumns .     
IsReadOnly . $��16(�6M   $	��Top=�6[   $��200,68,397.6,0q�6s      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5      $ 
TicketName��6%   $ 70 6X    69   �� *
TicketName+6X     5      $ Price��6%   $ 45 6N    64   �� *Price+6N     5      $ 
MaxTickets��6%    69   �� *
MaxTickets+5      5      5      