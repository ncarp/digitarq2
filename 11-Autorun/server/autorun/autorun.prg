# autorun.prg
#
# CDAutoRun version 1.0.2 written by Peter Harrison © 1999
# http://www.timeless.co.zw/
# With each command (specified within [ and ]) the lines following
# it are compulsory and the parameter order must not be changed.
# valid scripting commands:
#
# [splash]
# allup.bmp
# allhighlight.bmp
# alldown.bmp
# welcome.wav
# Title of Splash Screen
#
# [button]
# 20                     (start x position in window)
# 100                    (start y position in window)
# 200                    (end x position in window)
# 150                    (end y position in window)
# highlight.wav          (sound to play when highlighted)
# sound.wav              (sound to play when pressed)
# \myprog\setup.exe      (command to execute, use * for no action,
#                        assume that there are no paths setup, use
#                        explorer \ to browse this CD. The
#                        commercial version of CD AutoRun allows
#                        launching of URLs in the default web
#                        browser, e-mail peter@timeless.co.zw
#                        for more information about the comercial version)
# CloseAfterClick        (alternatively NoCloseAfterClick)

[splash]
allup.bmp
allit.bmp
alldown.bmp
welcome.wav
Configuração do DigitArq 2 - Servidor


# ==== 1.1 Microsoft .NET Framework Version 1.1 ====
[button]
55
222
377
244
lit.wav
click.wav
"..\Microsoft .NET Framework Version 1.1 Redistributable\dotnetfx.exe"
NoCloseAfterClick

# ==== 1.2 Microsoft .NET Framework Version 2.0 ====
[button]
55
246
377
269
lit.wav
click.wav
"..\Microsoft .NET Framework Version 2.0 Redistributable\dotnetfx.exe"
NoCloseAfterClick

# ==== 2.1 Instalação da base de dados (SQL Server 2000) ====
[button]
55
379
399
398
lit.wav
click.wav
"..\BD\SQLServer2000\bin\DBInstaller.exe"
NoCloseAfterClick

# ==== 2.2 Instalação da base de dados (SQL Server 2005) ====
[button]
55
403
400
422
lit.wav
click.wav
"..\BD\SQLServer2005\bin\DBInstaller.exe"
NoCloseAfterClick

# ==== 3.1 Módulo Disseminação, Navegação e Pesquisa ====
[button]
55
479
467
501
lit.wav
click.wav
"..\MDNP\setup.exe"
NoCloseAfterClick

# ==== 3.2 Módulo de Gestão de Utilizadores ====
[button]
55
503
470
525
lit.wav
click.wav
"..\MGUP\setup.exe"
CloseAfterClick





