|  Method   | Call      | csTime    | jsTime    | luaTime   | csResult  | jsResult  | luaResult |
|  :----    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    | :----:    |
| static void Payload();       | 1000       | 0.0ms       | 6.8ms       | 5.9ms       | `null`       | `null`       | `null`       |
| static void Payload();       | 10000       | 0.0ms       | 19.5ms       | 25.1ms       | `null`       | `null`       | `null`       |
| static void Payload();       | 100000       | 1.0ms       | 181.6ms       | 242.9ms       | `null`       | `null`       | `null`       |
| void Payload();       | 1000       | 1.0ms       | 2.9ms       | `fail`       | `null`       | `null`       | `null`       |
| void Payload();       | 10000       | 0.0ms       | 18.6ms       | `fail`       | `null`       | `null`       | `null`       |
| void Payload();       | 100000       | 1.0ms       | 191.7ms       | `fail`       | `null`       | `null`       | `null`       |
| static void Payload(int param1);       | 1000       | 1.0ms       | 4.5ms       | 3.9ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1);       | 10000       | 0.0ms       | 21.5ms       | 27.4ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1);       | 100000       | 0.0ms       | 224.7ms       | 281.5ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 4.9ms       | 4.9ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 28.3ms       | 32.2ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1, int param2, float param3);       | 100000       | 1.0ms       | 285.5ms       | 342.0ms       | `null`       | `null`       | `null`       |
| static void Payload(int param1, int param2, float param3);       | 1000       | 0.0ms       | 5.9ms       | 5.9ms       | 1501500       | 1003000       | 1003000       |
| static void Payload(int param1, int param2, float param3);       | 10000       | 0.0ms       | 34.2ms       | 41.0ms       | 1.500183E+08       | 1.0003E+08       | 100030000       |
| static void Payload(int param1, int param2, float param3);       | 100000       | 2.0ms       | 341.7ms       | 374.2ms       | 1.500022E+10       | 1.00003E+10       | 10000300000       |