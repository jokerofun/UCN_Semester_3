   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WpfApp.Views.UserTicketViewsWpfApp.Views.UserTicketViews  5   	   1    +WpfApp.Views.UserTicketViews.UserTicketMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:WpfApp.Views.UserTicketViews     5   	     � Title$  UserTicketMenu��5   	   $	��500��6    $	��800��6-   .��5	      � .+�5
   
   �� -   5        $��Update��5
      $
��Left=�6"   $��
21,153,0,0q�6=   $	��Top=�6Q   $��96��6i   6t   �� 5   
   -   5        $
��Back��5      $
��Left=�6    $��
30,405,0,0q�6;   $	��Top=�6O   $��75��6g   6r   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg��5         AutoGenerateColumns .     
IsReadOnly . $��16(�6M   $	��Top=�6[   $��157,68,40,0q�6s    J� RenderTransformOrigin$ -0.147,0.038&�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 0 6H      
Visibility$ 	Collapsed=�6R   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+6R     5      $ 
First Name��6%   $	 200 6W   	 69   �� *	FirstName+6W     5      $ 	Last Name��6%   $	 200 6U   	 68   �� *
LastName+6U     5      $ TicketID��6%   $	 100 6T   	 67   �� *
TicketId+6T     5      $ Active��6%   $	 100 6P   	 65   �� *Active+6P     5      $ UserId��6%   $ 0 6P   $ 	Collapsed=�6Z   	 65   �� *UserId+6Z   5      5      5      