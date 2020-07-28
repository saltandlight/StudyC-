# Chapter05. 기본, 참조, 값 타입🦁
## 프로그래밍 언어의 기본 타입
- 일부 데이터 타입들은 일반적이고 당연함 -> 많은 컴파일러들이 코드를 작성하는 동안 단순화된 문법의 형태로 이를 사용가능하도록 지원함
```C#
  System.Int32 a = new System.Int32;
```
- 그러나 정수형 변수를 선언, 초기화 위해 이처럼 하는 것은 번거로움...
- 다행히 C# 포함한 많은 컴파일러들은 단순한 문법 사용해서 쉽게 이 작업을 끝날 수 있게 함
```C#
  int a= 0;
```
- 처음의 문장과 의미가 동일한 IL 코드 만들어줌
- **기본 타입:** 컴파일러가 직접 지원하는 데이터 타입들
    - 프레임워크 클래스 라이브러리 상에 정의된 타입들과 직접 연결됨
    - 예: int 타입은 System.Int32 타입과 바로 연결됨
```C#
 int          a = 0;                 //가장 쓰기 쉬운 문법
 System.Int32 a = 0;                 //비교적 쉬움
 int          a = new int();         //불편함
 System.Int32 a = new System.Int32;  // 명시적이지만 너무 돌아가는 문법
```

| 기본타입 | FCL 타입       | CLS 호환 | 설명                                                         |
| -------- | -------------- | -------- | ------------------------------------------------------------ |
| sbyte    | System.SByte   | 아니오   | 부호 있는 8비트 정수값                                       |
| byte     | System.Byte    | 예       | 부호 없는 8비트 정수값                                       |
| short    | System.Int16   | 예       | 부호 있는 16비트 정수값                                      |
| ushort   | System.UInt16  | 아니오   | 부호 없는 16비트 정수값                                      |
| int      | System.Int32   | 예       | 부호 있는 32비트 정수값                                      |
| uint     | System.UInt32  | 아니오   | 부호 없는 32비트 정수값                                      |
| long     | System.Int64   | 예       | 부호 있는 64비트 정수값                                      |
| ulong    | System.UInt64  | 아니오   | 부호 없는 64비트 정수값                                      |
| char     | System.Char    | 예       | 16비트 유니코드 문자(char 타입은 비관리 C++에서 사용하던 8비트 값 포함하지 않음) |
| float    | System.Singloe | 예       | IEEE 32비트 부동 소숫값                                      |
| double   | System.Double  | 예       | IEEE 64비트 부동 소숫값                                      |
| bool     | System.Boolean | 예       | 참/거짓 논리 값                                              |
| decimal  | System.Decimal | 예       | 128비트 고해상도 부동 소수값이며 금융 관련 연산 위해 정의된 타입, 반올림 관련 오류 묵과되지 않음. 128비트 중 1비트는 부호 표기, 96비트는 값 자체를 표현, 8비트는 10의 지수 승을 표현, 앞의 96비트의 값을 나누기 위해 사용, 나머지 비트는 여유 공간으로 남김. 지수는 0~28 사이의값 |
| string   | System.String  | 예       | 문자의 배열                                                  |
| object   | System.Object  | 예       | 모든 타입들의 기본 타입                                      |
| dynamic  | System.Object  | 예       | 공용 언어 런타임 관점에서는 dynamic 키워드 자체는 object 타입과 동일하게 취급됨. 그러나 C# 컴파일러에서 dynamic 타입은 동적 코드를 처리하기 위한 단순화된 문법의 일부로 취급됨. |
- C# 컴파일러는 소스코드에 다음과 같은 using을 이용한 별칭 정의를 자동으로 삽입함
```C#
  using sbyte = System.SByte;
  using byte = System.Byte;
  using short = System.Int16;
  using ushort = System.UInt16;
  using int = System.Int32;
  using uint = System.UInt32;
```
## 참조 타입과 값 타입

## 박싱된 값 타입과 박싱되지 않은 값 타입

## 객체 해시 코드

## dynamic 기본 타입
