# Chapter04. 타입의 기초💃
## 모든 타입은 System.Object를 상속한다
- 모든 타입들은 System.Object 타입으로부터 파생됨
- 다음 두 클래스에 대한 선언은 완전 same
```C#
//암시적으로 System.Object 타입으로부터 파생됨
class Employee {
    //...
}
```

```C#
//명시적으로 System.Object 타입으로부터 파생됨
class Employee : System.Object{
    //...
}
```
- 모든 타입들이 System.Object 타입으로부터 파생됨 -> 최소한의 공통 기능을 모든 타입들이 동일하게 가짐

- [System.Object 타입의 Public 인스턴스 메서드]

- | Public 메서드 | 설명                                                         |
  | ------------- | ------------------------------------------------------------ |
  | Equals        | 비교 대상으로 지정한 객체와 동일한 값을 가지는 경우 true를 반환. 5장에 더 자세히... |
  | GetHashCode   | 객체의 값으로부터 해시코드를 만들어 반환. Dictionary와 같이 해시 테이블 컬렉션에서 객체 사용하려면 이 메서드를 반.드.시 재정의해야 함. 이 메서드로 만들어지는 해시 코드는 객체 식별할 수 있도록 충분한 유일성 만족해야 함. 이 메서드는 인터페이스에 반드시 정의되어 있음 |
  | ToString      | 이 메서드의 기본 구현은 현재 타입의 전체 이름을 문자열로 반환하는 것. this.GetType().FullName과 같은 기능을 함. 이 메서드는 객체의 현재 상태를 설명하기 위한 용도로 재정의되곤 함. 디버깅을 목적으로 이 메서드를 재정의하는 것도 일반적임. 객체의 필드 값을 보기 위해 이 메서드를 재정의하고 호출 가능함. 적절한 지역 설정을 반영하는 문자열을 반환하도록 만드는 것이 바람직함 |
  | GetType       | GetType 메서드를 호출하기 위해 사용된 객체의 타입을 설명하는 Type 타입으로부터 파생된 객체의 인스턴스를 반환함. GetType 메서드는 비가상 메서드로 정의됨. 그래서 파생 클래스가 이 메서드를 재정의할 수 없도록 보호, 이로서 타입에 대한 정보 속이거나 잘못 전달해서 타입 안정성을 위반하지 않도록 예방함 |

- [System.Object 타입의 Protected 인스턴스 메서드]

- | Protected 메서드 | 설명                                                         |
  | ---------------- | ------------------------------------------------------------ |
  | MemberwiseClone  | 이 메서드는 비가상 메서드로 현재 인스턴스와 동일한 타입의 새로운 인스턴스 생성함. 그 후 현재 만들어진 객체의 모든 필드를 새 객체로 복사해서 새 객체의 참조를 반환하는 기능을 구현함 |
  | Finalize         | 이 가상 메서드는 현재 객체가 더 이상 사용되지 않는다는 것을 가비지 컬렉터가 파악했을 때, 이 객체에 대한 메모리 공간에 대한 회수 요청이 들어왔을 때 호출됨. 별도로 정리작업을 수행할 필요가 있는 타입에서는 반드시 이 메서드를 재정의해야 함. |

- CLR은 모든 객체들을 반드시 new 연산자에 의해 만들도록 하고 있음
- 다음의 코드는 Employee 객체를 어떻게 만드는지 간단히 보여줌
`Employee e = new Employee("ConstructorParam1");`
- new 연산자가 하는 일
    - 1. 할당하려는 타입과 별도의 인스턴스가 없는 System.Object 타입을 포함한 그 위의 모든 기본 타입들에서 정의된 모든 인스턴스 필드들을 메모리에 할당하기 위한 바이트 수를 계산함. 힙 상의 모든 객체에는 별도의 추가적인 멤버로, 타입 객체 포인터(Type Object Pointer)와 동기화 블록 인덱스가 추가되며 CLR에 의해 객체를 관리하기 위해 사용됨. 이 추가 멤버들을 위한 바이트는 객체의 실제 크기에 포함됨
    - 2. 지정된 타입의 할당에 필요한 바이트의 수만큼 관리되는 힙으로부터 객체를 위해 메모리를 할당, 처음 할당 시 모든 바이트를 0으로 초기화함
    - 3. 객체의 타입 객체 포인터와 동기화 블록 인덱스 멤버를 초기화함
    - 4. 클래스 타입의 인스턴스 생성자+인수 -> new 연산자에서 서술한 대로 전달됨 각각의 호출되는 생성자는 타입에 의해 정의된 인스턴스 필드들을 초기화해야 함. 호출되는 생성자는 상속 관계에 따라 거슬러 올라가 최종적으로 System.Object의 생성자를 부름. 이 생성자는 하는 일 없이 반환됨

- new 연산자에 의해 모든 작업이 실행되면 새로 만들어진 객체의 참조(포인터)를 반환.
- 그런데...new 연산자에 대응되는 delete 연산자는 존재하지 않음, 명시적으로 객체의메모리를 할당 해제할 방법 없음
    
    - 가비지 컬렉션 기반의 메모리 관리 사용함으로 사용되지 않는 객체를 자동 추적, 메모리 해지 -> 메모리 공간 회수하는 일 자동으로 처리함

## 타입 간 캐스팅하기
- CLR의 중요한 기능들 중 하나는 타입 안정성~!
- 실행 시점에서 CLR은 객체의 정확한 타입이 무엇인지 항상 파악하고 있음

- 개발자들은 특정 객체를 다른 타입으로 캐스팅하는 코드를 자주 작성함
- CLR은 객체의 현재 타입에 근접한 타입 or 기본 타입으로 캐스팅을 지원함

- 기본 타입으로의 변환은 특별한 문법 불필요 <- 안전하게 처리할 수 있는 암묵적 변환이니까!
- 파생 타입으로의 형 변환은 명시적인 문법을 사용하게 함 <- 실행 시에 코드가 실패할 수 있으니까!
```C#
//이 타입은 암묵적으로 System.Object 클래스 타입으로부터 파생됨
internal class Employee{
    //...
}

public sealed class Program{
    public static void Main(){
        //Employee 클래스 타입은 Object 클래스 타입이 기본 타입임
        //new 연산자 호출 후에 별도로 형 변환 연산자 안 써도 됨
        Object o = new Employee();

        //Object 타입으로부터 Employee 클래스 타입이 파생되었으므로 형 변환 연산자가 필요함
        //Visual Basic이나 일부 다른 언어들은 캐스팅 없이 컴파일이 가능
        Employee e = (Employee) o;
    }
}
```
- 실행 시점에서 CLR은 캐스팅 연산자를 확인해서 캐스팅이 반드시 객체의 실제 타입 또는 기본 타입으로만 일어나는지 확인함
- 다음의 코드는 컴파일에는 성공하지만 실행 시점에서는 InvalidCastException 예외가 발생

```C#
internal class Employee{
    //...
}

internal class Manager : Emplyee{
    //...
}

public seaeld class Program {
    public static void Main() {
        //Manager 객체를 만들고 PromoteEmployee 메서드를 호출할 때 인수로 전달함
        //Manager is-a Object 관계 성립 -> PromoteEmployee 메서드가 정상적으로 실행됨
        Manager m = new Manager();
        PromoteEmployee(m);

        //DateTime 객체를 만들고 PromoteEmployee 메서드 호출 시 인수로 전달
        //DateTime 타입은 Employee 타입이 기본 타입이 아니므로 PromoteEmployee 메서드에서는 
        //System.InvalidCastException 예외가 발생하게 됨
        DateTime newYears = new DateTime(2013,1,1);
        PromoteEmployee(newYears);
    }

    public static void PromoteEmployee(Object o){
        // 이 시점에서, 컴파일러는 매개변수 o의 정확한 실제 타입이 뭔지 모름
        // 컴파일러는 컴파일을 우선 허용하게 됨
        // 그러나 실제 실행 시점에서 CLR은 object 타입으로 캐스팅이 되더라도 o객체가 어떤 타입인지 앍 ㅗ있고
        // o 객체가 Employee 혹은 Employee 로부터 파생된 타입인지 검사하게 됨
        Employee e = (Employee) o;
    }
}
```
- DateTime은 Object 타입으로 컴파일이나 실행 시점에서는 호출에 문제가 없다!
- 그러나 PromoteEmployee 메서드 안에서 CLR은 매개변수 o의 타입이 DateTime 타입인 것을 알 수 있고, Employee 또는 Employee 타입으로부터 파생된 타입과는 관련 없음을 알게 됨
- 이 시점에서 CLR은 캐스팅 허용 안 함, System.InvalidCastException 예외 발생시켜 실행 중단시킴

- 만약에 CLR이 여기서 캐스팅 허용한다면, 타입 안정성은 지켜지지 않음 -> 결과가 매우 불규칙적이게 되어서 불안정성을 야기
- -> 응용프로그램이 손상되거나 다른 타입으로 손쉽게 속일 수 있는 여지를 열어놓게 됨
- 이로 인해 수많은 보안 취약점 양산, 응용프로그램의 안정성, 신뢰도가 떨어짐
- 이런 까닭에 타입 안정성은 CLR에서 다른 어떤 부분보다 중요하고 철저하게 지켜짐

- 여기서는 PromoteEmployee 메서드의 매개변수 선언을 Object에서 Employee 타입으로 바꾸는 것이 타당함
- 그러나 그렇게 수정 시 앞의 코드에서 컴파일 오류가 발생...
- 이 동작 덕분에 개발자가 실행 시점에 이 문제를 찾게 될 때까지 걸리는 시간을 줄여줌

### C#의 is와 as 연산자로 캐스팅하기
- C# 언어에서 캐스팅 연산을 다루는 또 다른 방법: is 연산자를 사용하는 것
- C#의 is 연산자는 어떤 객체가 주어진 타입과의 호환성이 있는지 여부 판정 -> 참 또는 거짓으로 결과를 반환하는 기능이 있음
- 이 연산자는 절대! 예외를 발생시키지 않음
```C#
Object o = new Object();
Boolean b1 = (o is Object); //참
Boolean b2 = (o is Employee); //거짓
```
- 만약에 객체의 참조가 null이라면 is 연산자는 타입을 점검할 방법이 없으므로 항상 거짓을 결과로 내보냄
- is 연산자를 보통 사용함
```C#
if(o is Employee)
{
    Employee e = (Employee) o;
    //이 조건문 안에서 e 변수를 사용함
}
```
- 이 코드에서 CLR은 객체의 타입을 두 번 점검함
- is 연산자로 o 객체가 Employee 타입과의 호환성이 있는지 확인
    - 호환성이 있다면 if 코드 블록 안의 내용이 실행되어 CLR이 o 객체가 Employee 타입으로 캐스팅하면서 검사를 수행함
- CLR의 타입 검사는 보안을 강화하지만 성능에 관한 일정 비용이 발생
    - 비용이 발생하는 원인: CLR이 변수 o 에 들어있는 객체의 실제 타입을 파악하기 위해 상속 관계 탐색하면서 각 기본 타입들을 조사해야 하기 때문임
- 이런 프로그래밍 패러다임이 일반적이지만, C#은 이런 작업을 단순화하고 성능을 개선할 수 있도록 하기 위해 as 연산자를 제공함
```C#
Employee e = o as Employee;
if(e != null)
{
    //이 조건문 아네서 e 변수 사용
}
```
- 이 코드에서 CLR은 객체 o가 EMployee 타입과의 호환성이 있는지 점검
    - 그렇다면 해당 객체에 대한 유효한 참조를 캐스팅하여 반환
    - 아니라면 null 반환
- as 연산자는 CLR이 객체의 타입을 조회하고 검사하는 작업을 단 한 번만 수행한다는 것임
- 조건문 if에서는 단순히 이 연산의 결과로 나온 변수의 참조가 null인지 아닌지의 여부만 검사 -> 객체 타입을 좀 더 빠르게 검증할 수 있게 됨

- as 연산자는 예외를 전혀 발생시키지 않으면서 캐스팅 수행, 객체 캐스팅 불가능한 경우 null을 반환하게 됨
- 이를 이용해서 null인지 여부 판단하거나 이런 null을 담고 있는 객체의 인스턴스 메서드를 호출해서 의도적으로 System.NullReferenceException 예외를 발생시키도록 할 수 있음
```C#
Object o = new Object();        //새 Object 타입의 객체를 만듬
Employee e = o as Employee;     //o 변수의 참조를 Employee 타입으로 캐스팅함
//이 캐스팅은 실패하지만 예외 발생 안 하고 e가 null이 됨

e.ToString();
//변수 e에 대해 인스턴스 메서드 호출 시 NullReferenceException 예외 발생함
```
- [타입 안정성에 대한 퀴즈]

- 다음 두 클래스의 정의가 있다고 하자

- ```C#
  internal class B{	//기본 클래스
      
  }
  
  internal class D : B {  //파생된 클래스
      
  }
  ```

- | 문장                      | 이상 없음 | 컴파일 오류 | 실행 중 오류 |
  | ------------------------- | --------- | ----------- | ------------ |
  | Object o1 = new Object(); | O         |             |              |
  | Object o2 = new B();      | O         |             |              |
  | Object o3 = new D();      | O         |             |              |
  | Object o4 = o3;           | O         |             |              |
  | B b1 = new B();           | O         |             |              |
  | B b2 = new D();           | O         |             |              |
  | D d1 = new D();           | O         |             |              |
  | B b3 = new Object();      |           | O           |              |
  | D d2 = new Object();      |           | O           |              |
  | B b4 = d1;                | O         |             |              |
  | D d3 = b2;                |           | O           |              |
  | D d4 = (D) d1;            | O         |             |              |
  | D d5 = (D) b2;            | O         |             |              |
  | D d6 = (D) b1;            |           |             | O            |
  | B b5 = (B) o1;            |           |             | O            |
  | B b6 = (D) b2;            | O         |             |              |

```C#
    B b3 = new Object();
    D d2 = new Object(); 
```
- 위와 같은 경우는 다음과 같이 바꾸면 컴파일 오류가 나지 않는다.
- 애매해서 그런 듯!
```C#
    B b3 = new Object() as B;
    D d2 = new Object() as D;
```
- 암시적 변환을 하면 에러! 명시적으로 변환하면 정상!  

```C#
D d3 = b2;
```
- 이 경우, 에러가 나는데 b2는 이미 B 타입으로 선언되어 있으므로 D로 바꾸려면 다음과 같이 명시적으로 바꿔야 함!
- `D d3 = b2 as D;`

```C#
    D d6 = (D)b1;
    B b5 = (B)o1;
```
- 왜 실행 중 오류가 날까?
    - 자식 버전이 부모 버전보다 더 확장되고 좋은 개념인데 지금 부모를 강제로 자식형으로 바꿔줘서 그럼!

## 네임스페이스와 어셈블리
- 네임스페이스는 서로 관련이 있는 타입들을 논리적으로 그룹화하기 위한 수단
- 예)
    - System.Text 네임스페이스에는 문자열 조작에 관련된 타입들
    - System.IO 네임스페이스에는 입출력 연산에 관련된 타입들을 모아놓음
    - ```C#
        public sealed class Program
        {
            public static void Main()
            {
                System.IO.FileStream fs = new System.IO.FileSteram(...);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
            }
        }
    ```
- 이어지는 예시)
    - 근데 FileStream과 StringBuilder 타입을 좀 더 적게 타이핑하고 정확하게 가리키고 싶음
    - 다행히! 컴파일러가 이런 것들을 지원해줌! -> `using` 지시자를 이용하여 이것을 가능하게 함
    - 아래의 코드는 위의 코드와 같은 코드!
    - ```C#
        using System.IO;   //접두사를 미리 붙임
        using System.Text;
        public sealed class Program
        {
            public static void Main()
            {
                FileStream fs = new FileSteram(...);
                StringBuilder sb = new StringBuilder();
            }
        }
    ```
- 컴파일러 입장에서 네임스페이스는 타입의 이름을 길게 확장하면서 더 고유한 이름을 가질 수 있도록 만들어주는 쉬운 방법!
- 이런 이름을 컴파일러가 해석하게 되면 FileStream 클래스 타입의 경우 Systme.IO.FileStream 클래스 타입을 가리키는 것으로 이해함
- **CLR은 네임스페이스에 대해 아무것도 모른다.**
    - 어떤 타입 사용하려고 할 떄, CLR은 구분자 기호가 들어갈 수 있는 타입의 전체 이름만 필요
    - 해당 타입을 어떤 어셈블리에서 가지고 있는지 알 수 있어야 함
    - 이 조건들을 만족해야 실행 시에 올바른 어셈블리를 로드하고 타입 찾아서 코드 처리가 가능함!
- 어떤 타입에 대한 정의를 검사할 때, /reference 컴파일러 스위치를 이요하여 검사하려는 어셈블리를 컴파일러에게 전달해줘야 함
- 이를 통해 컴파일러는 특정 타입에 대한 정의 찾기 위해 참조 대상으로 지정된 모든 어셈블리를 검색하게 됨
- 컴파일러가 정확한 어셈블리 찾음 -> 어셈블리 정보오 ㅏ타입 정보가 만들어지는 ㅗ간리 모듈의 메타 데이터상에 기록됨
- 어셈블리 정보를 가져오기 위해서는 컴파일러에 반드시 참조하는 타입이 정의된 어셈블리에 대한 정보를 전달해야 함
- 컴파일러는 기본적으로 MSCORLIB.DLL 어셈블리를 자동으로 찾아볼 대상에 포함시킴
    - 이 어셈블리에는 Object, Int32, String 등의 핵심적인 타입들을 모두 포함하는 FCL이 들어있음
- 다른 어셈블리 안에서 둘 다 같은 이름의 클래스가 있고, 프로그래머가 그것을 사용하려고 한다면 Full name을 써줘야 모호한 참조 메세지가 뜨지 않음

- C# 의 using 구문의 한 형태 이용 시 특정 타입에 대한 별명 만들 수 있음
    - 모든 네임스페이스를 글로벌 네임스페이스로 병합 안 하고 원하는 타입만 갖고와서 쓰면 되므로 유용!
    - 모호한 참조도 피할 수 있음!

```C#
using Microsoft;    // "Microsoft."을 접두사로 사용
using Wintellect;   // "WinTellect."을 접두사로 사용
// Wintellect.Widget 클래스 타입을 다음의 새로운 별명으로 정의!
using WintellectWidget = Wintellect.Widget;

public sealed class Program
{
    public static void main()
    {
        WintellectWidget w = new WintellectWidget();
    }
}
```
- 만약 이름마저도 같은 namespace를 두 개 이상 사용하고, 클래스 이름마저도 같은 것을 하나의 프로그램에서 사용한다면 두 타입의 구분이 불가능하게 됨
- 이를 위해서 C# 컴파일러는 extern 별칭이라는 기능을 제공해서 해결책 제시
- extern 별칭을 이용하면 네임스페이스까지 동일한 서로 다른 어셈블리 상의 하나 이상의 타입 or 버전만 다른 어셈블리들 안에 들어있는 동일한 타입 구별 가능
- 제 3자가 사용하는 타입을 설계하려는 경우, 이런 타입들을 별도의 네임스페이스 상에 정의해서 컴파일러가 쉽게 타입 구분할 수 있도록 해야 함
- 이런 충돌 가능성 최소화하기 위해서 머리글자나 약칭으로 축약한 이름보다 회사의 전쳉 ㅣ름을 최상위 네임스페이스 이름으로 채택해주는 것이 좋음

- 네임스페이스를 선언하는 방법:
```C#
namespace CompanyName {
    public sealed class A {     //TypeDef: CompanyName.A

    }

    namespace X{
        public sealed class B{  //TypeDef: CompanyName.X.B

        }
    }
}
```
- 몇몇 컴파일러들은 네임스페이스를 지원하지 않음
- 또 다른 컴파일러들은 특정 언어에서 사용할 네임스페이스라는 개념을 자유롭게 정의할 수 있도록 허용하기도 함
- C#의 경우 namespace 지시자를 통해 같은 접두사를 가지게 되는 타입들끼리는 소스 코드상에서 전체 네임스페이스 이름을 모두 타이핑하지 않고도 타입을 찾을 수 있도록 컴파일러에 제시하는 기능을 하게 됨

## 실행 시점과의 연관성
![](pic1.PNG)
- 단일 Windows 프로세스에서 CLR을 로드할 때 메모리 구조
- 하나 이상의 스레드가 만들ㅇ져 있음
- 새로운 스레드를 만들 때에는 스레드당 1MB 크기의 스택이 할당됨
- 이 스택 공간은 메서드로 인수를 전달하는 과정에서 사용하거나 메서드 내에서 사용하는 지역변수를 보관하기 위해 사용됨
- 스택은 상위 메모리 주소에서 하위 메모리 주소에 걸쳐 만들어짐

- 이 스레드가 M1 메서드 안에 들어있는 코드를 실행했다고 가정하자

![](pic2.PNG)
- 메서드들은 **프롤로그 코드**를 포함, 이 코드 통해 메서드 안의 코드가 작동가능하도록 초기화 거치게 됨
- 여기에 대응되는 **에필로그 코드**도 있음, 이 코드 통해 메서드 실행 후의 정리 작업 수행, 원래의 호출자에게 되돌아갈 수 있도록 준비하게 됨
- M1 메서드 실행이 시작되면 프롤로그 코드가 이 그림처럼 스레드 스택에 지역 변수 name을 위한 메모리 공간을 할당하게 됨

![](pic3.PNG)
- M1은 M2 메서드를 호출하면서 name 지역 변수를 매개변수로서 전달하게 됨
- 이 과정에서 name 지역 변수의 주소가 스택에 저장됨
- M2 메서드 내부에서는 스택의 주소가 매개변수 s에 의해 식별됨
- 메서드가 호출될 때 피호출자 메서드의 실행이 끝난 후 돌아갈 호출자 메서드의 주소도 스택상에 저장됨


![](pic4.PNG)
- M2가 실행되면, M2 메서드의 프롤로그 코드에서는 지역변수 length와 tally를 스레드 스택상에 할당하게 됨
- M2 메서드의 코드가 실행됨
- M2는 Return Statement를 만나서, CPU의 명령 포인터의 주소를 스택에 저장된 호출자 메서드의 주소로 설정
- 그 후, M2의 스택 프레임은 두 번째 그림처럼 됨
- 이 시점에서, M1은 M2 메서드를 호출한 직후의 코드에서부터 실행 재개, 스택 프레임은 호출 당시의 상태로 재구성됨
- 또 다시 M1 메서드는 M1 메서드의 호출자로 돌아가기 위해 CPU의 명령 포인터를 스택상에 저장된 호출자의 주소로 설정, M1의 스택 프레임을 첫 번째 그림처럼 해제하게 됨

- 이제 CLR을 살펴볼 것
- 다음의 두 개의 클래스 정의가 있다고 가정하자

```C#
internal class Employee{
    public         Int32    GetYearsEmployed() { ... }
    public virtual String   GetProgressReport() { ... }
    public static  Employee Lookup(String name) { ... }
}

internal sealed class Manager : Employee {
    public override String  GetProgressReport() { ... }
}
```
- Windows 프로세스 실행, CLR이 그 안에 로드됨, 관리되는 힙이 초기화, 1MB 크기의 스택공간과 함께 스레드가 할당될 것
- 이 스레드는 이미 코드를 모두 실행한 상태
- M3라는 메서드상의 코드를 실행하려고 함

![](pic4.PNG)
- JIT 컴파일러가 M3 메서드의 IL 코드를 네거티브 CPU 명령어로 변환하면서 M3 메서드 안에서 참조하는 Employee, Int32, Manager, 그리고 "Joe"라는 상수 문자열에 관해 사용되는 String 타입까지 모든 타입들을 파악하게 됨
- 이 시점에서 CLR은 이런 타입들을 포함하는 어셈블리들을 모두 로드하게 될 것
- CLR은 어셈블리의 메타데이터 사용 -> 이 타이븓ㄹ에 대한 정보 추출 -> 타이벵 대한 정보를 서술하는 자료구조를 생성하게 될 것