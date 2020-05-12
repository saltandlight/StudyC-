# Converting과 Casting
## Converting
- 프로그래머가 "1"을 1로 바꿔주는 것과 같음
- "1.6"을 Integer로 Converting 하면 반올림이 될 수 있음
- 순수한 값이 아니라 변환된 값

## Casting
- 형 정보를 씌워주는 것
- Integer to object인 경우: 값은 그대로이지만 Integer형이라는 형 정보가 소실됨
```C#
public class A
{
  public void testA
  {
      ...
  }
}

public class B : A
{
    public void testB
    {
        ...
    }
}

static public void main(string[] args)
{
    A a = new A();
    B b = new B();

    var c = (A)b;
    //이 때, c는 B에 대한 함수를 가지고 있지만 B 타입에 대한 정보를 소실했음 -> testB 함수를 찾을 수 없습니다...

    c = b as B;
    //이 때, c는 B에 대한 타입 정보를 받아옵니다. -> testB 함수 사용 가능
}
```
- 이 두 가지의 경우를 봤을 때, 위의 c와 아래의 c는 온전한 B이지만 위의 경우 **B 타입에 대한 정보**를 소실해서 B로 온전히 기능하지 못함
 

## 결론
```C#
var a=Integer.Parse("1");
```
의 결과와 아래의 결과는 같지만 의미는 완전히 다름
```C#
object num = 1;
var a = num as Integer;
```
- 둘은 엄연히 다릅니다.
