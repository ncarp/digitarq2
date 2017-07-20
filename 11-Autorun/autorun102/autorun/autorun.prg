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
Configuração do DigitArq 2 - Cliente


# ==== 1.1 Microsoft .NET Framework Version 1.1 ====
[button]
55
263
378
285
lit.wav
click.wav
"..\Microsoft .NET Framework Version 1.1 Redistributable\dotnetfx.exe"
NoCloseAfterClick

# ==== 1.2 Microsoft .NET Framework Version 2.0 ====
[button]
55
289
377
310
lit.wav
click.wav
"..\Microsoft .NET Framework Version 2.0 Redistributable\dotnetfx.exe"
NoCloseAfterClick

# ==== 1.3 Microsoft SQL Server 2005 Express Edition ====
[button]
55
281
418
301
lit.wav
click.wav
"..\SQLEXPR\SQLEXPR_ADV.exe"
NoCloseAfterClick


# ==== 2.1 Módulo de Descrição Arquivística ====
[button]
55
355
345
376
lit.wav
click.wav
"..\MDA\setup.exe"
NoCloseAfterClick

# ==== 2.2 Módulo de Gestão de Objectos Digitais ====
[button]
55
380
389
402
lit.wav
click.wav
"..\MGOD\setup.exe"
NoCloseAfterClick

# ==== 2.3 Módulo de Publicação de Objectos Digitais ====
[button]
55
405
417
526
lit.wav
click.wav
"..\MPOD\setup.exe"
CloseAfterClick
