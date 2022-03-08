# PerformanceTesting
 Unity游戏引擎, C#原生丶puerts脚本丶xLua脚本性能测试横向对比
 
 
|  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
|  ----     | ----      | ----      | ----      | ----      | ----      | ----      | ----      |
| static void Payload();       | 1000       | 0.0ms       | 4.9ms       | 4.9ms       | <null>       | <null>       | <null>       |
| static void Payload();       | 10000       | 0.0ms       | 17.6ms       | 24.4ms       | <null>       | <null>       | <null>       |
| static void Payload();       | 100000       | 1.0ms       | 192.5ms       | 257.0ms       | <null>       | <null>       | <null>       |
| void Payload();       | 1000       | 0.0ms       | 3.9ms       | Fail       | <null>       | <null>       | <null>       |
| void Payload();       | 10000       | 0.0ms       | 20.5ms       | Fail       | <null>       | <null>       | <null>       |
| void Payload();       | 100000       | 1.0ms       | 201.3ms       | Fail       | <null>       | <null>       | <null>       |
| static void Payload(int param1);       | 1000       | 0.0ms       | 3.9ms       | 3.9ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1);       | 10000       | 1.0ms       | 22.5ms       | 26.4ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1);       | 100000       | 1.0ms       | 234.5ms       | 297.9ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 4.9ms       | 3.9ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 32.3ms       | 38.6ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 312.5ms       | 359.4ms       | <null>       | <null>       | <null>       |
| static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 4.9ms       | 5.9ms       | 1501500       | 1003000       | 1003000       |
| static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 34.2ms       | 36.2ms       | 1.500183E+08       | 1.0003E+08       | 100030000       |
| static void Payload(int param1, int param2, float param3);       | 100000       | 2.9ms       | 336.1ms       | 379.1ms       | 1.500022E+10       | 1.00003E+10       | 10000300000       |
