import sqlite3, shutil
origem = r'C:\Users\Administrator\AppData\Local\Temp\positron-limpeza.db'
copia = r'C:\Users\Administrator\AppData\Local\Temp\positron-cabos-sonda.db'
shutil.copyfile(origem, copia)
c = sqlite3.connect(copia)
print('antes: Funcao vazia Cabos =', c.execute("SELECT COUNT(*) FROM Cabos WHERE Funcao = ''").fetchone()[0])
print('antes: Funcao vazia Cabos4 =', c.execute("SELECT COUNT(*) FROM Cabos4 WHERE Funcao = ''").fetchone()[0])
print('antes: linhas em Cabos =', c.execute('SELECT COUNT(*) FROM Cabos').fetchone()[0])
c.execute("UPDATE Cabos SET Funcao = ' ' WHERE Funcao = ''")
c.execute("UPDATE Cabos4 SET Funcao = ' ' WHERE Funcao = ''")
c.execute('UPDATE Cabos SET Alarme = 0')
c.commit()
print('depois: Funcao vazia Cabos =', c.execute("SELECT COUNT(*) FROM Cabos WHERE Funcao = ''").fetchone()[0])
print('depois: Funcao vazia Cabos4 =', c.execute("SELECT COUNT(*) FROM Cabos4 WHERE Funcao = ''").fetchone()[0])
c.close()
