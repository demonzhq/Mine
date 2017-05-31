
import SocketServer
import time
import sched
from threading import Timer
import string
import os
from math import pi,sqrt,sin,cos




strfile = "D:/job.txt"
strGPSfile = "D:/gps.txt"
port = 8009
server = '127.0.0.1'



a = 6378245.0
ee = 0.00669342162296594323

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
                elif (data.startswith('GPS')):
                    WGS84_Lat = ord(data[3])-89+(((((ord(data[5])<<6)+(ord(data[6])>>2))*0.0001)+((ord(data[4])>>2)))/60)
                    WGS84_Long = (ord(data[7])<<1)+(ord(data[8])>>7)-179+(((((ord(data[9])<<6)+(ord(data[10])>>2))*0.0001)+((ord(data[8])&0x7f)>>1))/60)
                    gps=transform(WGS84_Lat,WGS84_Long)
                    fp = file(strGPSfile, 'wt')
                    fp.write("http://uri.amap.com/marker?position="+str(gps[1])+','+str(gps[0]))     
                    fp.close()
                    conn.send("GPS Received")
                elif (data.startswith('GETGPS')):
                     if os.path.lexists(strGPSfile):
                        fp = file(strGPSfile, 'rt')
                        s = fp.readline()
                        fp.close()
                        conn.send(s)               
                else: 
                    CurrentTime = time.strftime('%Y-%m-%d_%H:%M:%S',time.localtime(time.time()))
                    conn.sendall(data + '_' + CurrentTime)
        except Exception, e:
            print(e)
            Flag = False


def transform(wgLat, wgLon):
    """
    transform(latitude,longitude) , WGS84
    return (latitude,longitude) , GCJ02
    """
    if (outOfChina(wgLat, wgLon)):
        mgLat = wgLat
        mgLon = wgLon
        return
    dLat = transformLat(wgLon - 105.0, wgLat - 35.0)
    dLon = transformLon(wgLon - 105.0, wgLat - 35.0)
    radLat = wgLat / 180.0 * pi
    magic = sin(radLat)
    magic = 1 - ee * magic * magic
    sqrtMagic = sqrt(magic)
    dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi)
    dLon = (dLon * 180.0) / (a / sqrtMagic * cos(radLat) * pi)
    mgLat = wgLat + dLat
    mgLon = wgLon + dLon
    return mgLat,mgLon
def outOfChina(lat, lon):
    if (lon < 72.004 or lon > 137.8347):
        return True
    if (lat < 0.8293 or lat > 55.8271):
        return True
    return False

def transformLat(x, y):
    ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * sqrt(abs(x))
    ret += (20.0 * sin(6.0 * x * pi) + 20.0 * sin(2.0 * x * pi)) * 2.0 / 3.0
    ret += (20.0 * sin(y * pi) + 40.0 * sin(y / 3.0 * pi)) * 2.0 / 3.0
    ret += (160.0 * sin(y / 12.0 * pi) + 320 * sin(y * pi / 30.0)) * 2.0 / 3.0
    return ret

def transformLon(x, y):
    ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * sqrt(abs(x))
    ret += (20.0 * sin(6.0 * x * pi) + 20.0 * sin(2.0 * x * pi)) * 2.0 / 3.0
    ret += (20.0 * sin(x * pi) + 40.0 * sin(x / 3.0 * pi)) * 2.0 / 3.0
    ret += (150.0 * sin(x / 12.0 * pi) + 300.0 * sin(x / 30.0 * pi)) * 2.0 / 3.0
    return ret

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
    server = SocketServer.ThreadingTCPServer((server,port),MyServer)
    server.serve_forever()