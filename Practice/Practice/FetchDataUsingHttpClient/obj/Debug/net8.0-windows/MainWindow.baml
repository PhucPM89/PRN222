   M S B A M L   `   `   `  ����S  OFetchDataUsingHttpClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:FetchDataUsingHttpClientFetchDataUsingHttpClient  5   	   )    #FetchDataUsingHttpClient.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:FetchDataUsingHttpClient     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � 
����ح� � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   6,   .+�5   
   �� $��Stretch=�6   $��Stretch=�5       �� Orientation$ Vertical=�5      .+�5      �� -   5        $��lblURL��5      $	��URL��6"   62   �� 5      -   5        $��txtURL��5      $��https://dantri.com.vn/��6$   $��25��6B   6P   �� 5      -   5        $��
lblContent��5      $��HTML Source��6&   6>   5      �� 5   
   -   5        $��
txtContent��5      $��1��6    �� TextWrapping$
 Wrap=�61   $ �� HorizontalScrollBarVisibility$
 Auto=�5       �� AcceptsReturn$
 True��5      " �� VerticalScrollBarVisibility$ Visible=�5      6:   �� 5   
   $��2��6   $ 
Horizontal=�6"   $��Center=�5      $	��Top=�5      .+�5      �� -   5         ��Name$ btnViewHTML��5      $
��25.5q�6*   $��80��68   $��	View HTML��6C   6W   �� 5      -   5        $ btnClear��5      $
��25.5q�6(   $��80��66   $��Clear��6A   6Q   �� 5      -   5        $ btnClose��5      $
��25.5q�6(   $��80��66   $��Close��6A   6Q   5       5!      5"      