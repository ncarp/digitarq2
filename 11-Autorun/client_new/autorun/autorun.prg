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
alldown.bmp
alldown.bmp
welcome.wav
Configuração do DigitArq 2 - Cliente - Versão CMO


# ==== 1.1 Crystal Reports runtime engine (versão 32bits) ====
[button]
58
268
438
285
lit.wav
click.wav
"..\requirements\CrystalReports\CRRuntime_32bit.cmd"
NoCloseAfterClick

# ==== 1.2 Crystal Reports runtime engine (versão 64bits) ====
[button]
58
293
438
310
lit.wav
click.wav
"..\requirements\CrystalReports\CRRuntime_64bit.cmd"
NoCloseAfterClick

# ==== 2.1 Módulo de Descrição Arquivística ====
[button]
58
358
340
375
lit.wav
click.wav
"..\release\01-MDA\setup.exe"
NoCloseAfterClick

# ==== 2.2 Módulo de Gestão de Objectos Digitais ====
[button]
58
384
383
400
lit.wav
click.wav
"..\release\02-MGOD\setup.exe"
NoCloseAfterClick

# ==== 2.3 Módulo de Publicação de Objectos Digitais ====
[button]
58
408
412
425
lit.wav
click.wav
"..\release\03-MPOD\setup.exe"
CloseAfterClick
