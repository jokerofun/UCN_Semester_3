   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WpfApp.Views.TripViewsWpfApp.Views.TripViews  5   	   %    WpfApp.Views.TripViews.TripMenu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   0local$clr-namespace:WpfApp.Views.TripViews  5   	     � Title$  TripMenu��5
   	   $	��500��6   $
��1200��6'   .��5      � .+�5   
   "  FontAwesome.WPF.ImageAwesome     Icon$
 Ship=�6   $��Center=�6&   $��Center=�6A   $��47��6^   $��30,15,1116.6,416.4q�6i   $��39��6�   �� 5   
   -   5        $��Create��5      $
��Left=�6"   $��	21,68,0,0q�6=   $	��Top=�6P   $��96��6h   6s   �� 5   
   -   5        $��	Show Info��5      $
��Left=�6%   $��
21,113,0,0q�6@   $	��Top=�6T   $��96��6l   6w   �� 5   
   -   5        $��Delete��5      $
��Left=�6"   $��
21,190,0,0q�6=   $	��Top=�6Q   $��96��6i   6t   �� 5   
   -   5        $��Update��5      $
��Left=�6"   $��
21,153,0,0q�6=   $	��Top=�6Q   $��96��6i   6t   �� 5   
   -   5        $
��Back��5      $
��Left=�6    $��
30,405,0,0q�6;   $	��Top=�6O   $��75��6g   6r   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg��5         AutoGenerateColumns .     
IsReadOnly . $��16(�6M   $	��Top=�6[   $��157,68,9.6,0q�6s    J� RenderTransformOrigin$ -0.147,0.038&�6�    � 	Resources 5      )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 5      "  6   .�5      -   5        5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+6H     5      $
	 Name��6%   $
 80 6L    63   �� *Name+6L     5      $	 Description��6%   $	
 150 6Z    6:   �� *Description+6Z     5      $	 DeparturePlace��6%   $	
 144 6`    6=   �� *DeparturePlace+6`     5      $	 ArrivalPlace��6%   $	
 118 6\    6;   �� *ArrivalPlace+6\     5      $	 DepartureDate��6%   $	
 180 6^    6<   �� *DepartureDate+6^     5       $	 ArrivalDate��6%   $	
 180 6Z    6:   �� *ArrivalDate+6Z     5!      $	 UserId��6%   $
 0 6P      
Visibility$ 	Collapsed=�6Z    65   �� *UserId+6Z   5#      �� 5$   
   -   5        $��
searchName��5$      $
��Left=�6$   $��24��6?   $��
186,39,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��101��6�   6�   �� 5%   
   $
��Name��6   $
��Left=�6   $��24��6:   $��
214,15,0,0q�6F   $	��Top=�6Z   $��42��6r   �� 5&   
   $��DeparturePlace��6   $
��Left=�6)   $��
353,15,0,0q�6D   $	��Top=�6X   �� 5'   
   $��ArrivalPlace��6   $
��Left=�6'   $��
533,16,0,0q�6B   $	��Top=�6V   �� 5(   
   $��DepartureDate��6   $
��Left=�6(   $��
715,15,0,0q�6C   $	��Top=�6W   �� 5)   
   $��ArrivalDate��6   $
��Left=�6&   $��
909,16,0,0q�6A   $	��Top=�6U   �� 5*   
   -	   5        $��searchDeparturePlace��5*      $
��Left=�6.   $��23��6I   $��
337,40,0,0q�6U   $
 Wrap=�6i   $	��Top=�6}   $	��120��6�   6�   �� 5+   
   -
   5        $��searchArrivalPlace��5+      $
��Left=�6,   $��23��6G   $��
507,40,0,0q�6S   $
 Wrap=�6g   $	��Top=�6{   $	��120��6�   6�   (  "System.Windows.Controls.DatePicker  5,   
   -   5        $��searchDepartureDate��5,      $
��Left=�60   $��
693,38,0,0q�6K   $	��Top=�6_   $	��130��6w   |�.  6�     5-   
   -   5        $��searchArrivalDate��5-      $
��Left=�6.   $��
872,38,0,0q�6I   $	��Top=�6]   $	��138��6u   |�.  6�   �� 5/   
   $��Search��6   $
��Left=�6"   $��1035,35,0,0q�6=   $	��Top=�6R   $��75��6j   50      51      