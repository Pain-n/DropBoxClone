   M S B A M L   `   `   `  ����M  IClientDropBoxClone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ClientDropBoxCloneClientDropBoxClone  5   	   #    ClientDropBoxClone.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ClientDropBoxClone     5   	     � Title$  DropBoxClone��5   	   $	��450��6   $	��800��6+   .��5	      � -   5         �Name$ AppMainWindow��5	       � ColumnDefinitions 5
   
   �� 5      $	��11* �6   �� 5      $
��789* �6   .+�5   
   �� -   5         ��Name$ FileListLable��5      $��1��6'   $��Список файлов��67   $
��Left=�6O   $��	10,10,0,0q�6j   $	��Top=�6}   $��27��6�   $	��144��6�   �� 5   
   -   5         ��Name$ AddFileButton��5      $��1��6(   $��Добавить��68   $
��Left=�6K   $��
537,37,0,0q�6f   $	��Top=�6z   $��50��6�   $	��150��6�   6�   �� 5   
   -   5        $ DownloadFileButton��5      $��1��6-   $��Скачать��6=   $
��Left=�6O   $��537,217,0,0q�6j   $	��Top=�6   $��50��6�   $	��150��6�   6�   �� 5   
   -   5        $ DeleteFileButton��5      $��1��6+   $��Удалить��6;   $
��Left=�6M   $��537,128,0,0q�6h   $	��Top=�6}   $��50��6�   $	��150��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ FileListDataGrid��5      $��1��6-   $��10,37,311,32q�6X   �� 5   
   -   5         ��Name$ debug��5      $��1��6!   $
��Left=�61   $��537,310,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   $��80��6�   5      5      