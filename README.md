# Keeper

[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Build Status](https://travis-ci.org/shimanov/Keeper.svg?branch=master)](https://travis-ci.org/shimanov/Keeper)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/a46398a708d24053bec54deccb692176)](https://www.codacy.com/app/shimanov/Keeper?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=shimanov/Keeper&amp;utm_campaign=Badge_Grade)

## Приложение для перезапуска служб и выполнения хранимых процедур

Возможности приложения
-----------------------
### Если в каталоге Export нет файла gmmq.packedge.end, тогда:
* Производится очистка каталога от всех файлов и подкаталогов
* Выполняется хранимая процедура на выгрузку реплики

### Если в каталоге Export есть файл gmmq.packedge.end, тогда
* Выполняется хранимая процедура на загрузку реплики
* Если файл gmmq.packedge.end отсутствует, очищаем каталог 
         и выполняем хранимую процедуру на выгрузку реплики
         
### Перезапуск служб производится через 5 минут, после выполнения хранимых процедур
### Если службы были остановлены, производится запуск служб


Запуск и установка
-----------------------
Для запуска приложения необходимо установить .net framework 4.5.1 (в дистрибутив не входит).
Приложение не требует установки.

Лицензия
-----------------------
[Apache 2.0](https://opensource.org/licenses/Apache-2.0)
