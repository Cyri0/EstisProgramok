   M S B A M L   `   `   `  ����B  >Secrets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SecretsSecrets  5   	       Secrets.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Secrets     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ usernameGUI��5
      $
��Left=�6'   $��25��6B   $��	60,59,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��145��6�   �� 5   
   $��Felhasználónév��6   $
��Left=�6)   $��	60,38,0,0q�6D   $	��Top=�6W   $��0,0,5,5q�6o   �� 5   
   $��Jelszó��6   $
��Left=�6!   $��
60,103,0,0q�6<   $	��Top=�6P   $��0,0,5,5q�6h   G� 5   
   -   5         G�Name$ passwordGUI��5      $
��Left=�6+   $��
60,124,0,0q�6F   $	��Top=�6Z   $	��145��6r   $��25��6~   �� 5   
   -   5         ��Name$ showBtn��5      $��Mutasd a titkokat!��6"   $
��Left=�6?   $��
81,192,0,0q�6Z   $	��Top=�6n   $	��124��6�   $��25��6�   6�   �� 5   
   -   5         ��Name$ 
secretsGUI��5      $
��Left=�6&   $	��306��6A   $��
315,48,0,0q�6N   $	��Top=�6b   $	��440��6z   �� 5   
   -   5        $ newSecretGUI��5      $
��Left=�6(   $��25��6C   $��315,364,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��320��6�   �� 5   
   -   5        $ addSecretBtn��5      $��Elkotyog��6'   $
��Left=�6:   $��25��6U   $��645,364,0,0q�6a   $	��Top=�6v   $	��110��6�   6�   �� 5   
   -   5        $ regBtn��5      $��Regisztrálok��6!   $
��Left=�68   $��25��6S   $��
81,229,0,0q�6_   $	��Top=�6s   $	��124��6�   6�   5      5      