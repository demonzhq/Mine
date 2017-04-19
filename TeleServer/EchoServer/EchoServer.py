
import SocketServer
import time
import sched
from threading import Timer
import string
import os




strfile = "D:/job.txt"
port = 8009


class MyServer(SocketServer.BaseRequestHandler):
    def handle(self):
        JobIndex = 0;
        conn = self.request
        conn.sendall('Hello ' + self.client_address[0] + ":" + str(self.client_address[1]))
        Timer(1,  print_time, (conn, JobIndex, )).start()    
        Flag = True
        jobcount = 0;
        try:
            while Flag:
                data = conn.recv(1024)
                if data == 'exit':
                    Flag = False
                elif (data.startswith('send_')):                   
                    if os.path.lexists(strfile):
                        fp = file(strfile, 'rt')
                        s = fp.readline()
                        fp.close()
                        slist = s.split("_")
                        if len(slist) == 2:
                            jobcount = int(slist[0]) + 1
                        fp.close()
                    fp = fp = file(strfile, 'wt')
                    fp.write(str(jobcount) + "_" + data[5:len(data)])      
                    fp.close()            
                    conn.sendall("Command Received")
                else: 
                    CurrentTime = time.strftime('%Y-%m-%d_%H:%M:%S',time.localtime(time.time()))
                    conn.sendall(data + '_' + CurrentTime)
        except Exception, e:
            Flag = False

def print_time( conn, JobIndex ):  
    # conn.sendall(str(JobIndex))
    if os.path.lexists(strfile):
        fp = file(strfile, 'rt')
        s = fp.readline()
        fp.close()
        slist = s.split("_")
        if len(slist) == 2:
            jobcount = int(slist[0])
            if jobcount > JobIndex:
                JobIndex = jobcount
                conn.sendall(slist[1])
    Timer(1,  print_time, ( conn, JobIndex, )).start()

if __name__ == '__main__':
    server = SocketServer.ThreadingTCPServer(('127.0.0.1',port),MyServer)
    server.serve_forever()