# Chapter01. CLR의 실행모델☘️
- 이 장의 목표:
    - .NET Framework는 어떻게 설계되었는가
    - .NET Framework가 포함하는 기술들
    - .NET Framework 용어들
    - 작성한 코드를 하나 이상의 클래스나 구조체 등의 타입을 포함하는 응용프로그램이나 재배포가 가능한 구성요소로 만드는 과정
    - 만든 응용프로그램이 어떻게 실행되는지 

## 소스코드를 관리 모듈로 컴파일하기
- 어떤 종류의 응용프로그램이나 구성요소를 만들 것인지 구상해야 함

- 어떤 프로그래밍 언어를 사용하여 프로그램을 만들 것인지 결정할 차례

- 각각의 언어들은 서로 다른 가능성과 장점을 가지고 있으므로 선택하기 쉽지 않음

- 예시: 비관리(Unmanaged) C/C++의 경우 상당히 낮은 수준(row-level)까지 시스템 제어 가능
  
    - 메모리를 어떤 방식으로 사용하고 관리할 것이지를 세밀하게 관리 가능, 필요에 따라 쓰레드 만들 수 있음, 이 외에도 여러 가지가 있음
    
- 예시: Visual Basic 6.0의 경우, 사용자가 UI를 쉽고 빠르게 만들 수 있도록 도움을 주고 COM(Component Object Model) 객체와 데이터베이스에 대한 제어를 간단하게 처리가능하게 함

- 공용 언어 런타임(Common Language Runtime, CLR)은 서로 다른 프로그래밍 언어들 사이에서 공동으로 사용 가능한 실행환경(Runtime)임
    - CLR의 핵심 기능들: 메모리 관리, 어셈블리 로딩, 보안, 예외 처리, 스레드 동기화 등
    - 이 기능들은 CLR을 지원하는 어떤 프로그래밍 언어라도 제약없이 자유롭게 사용 가능함
    - 실행 시점에서 발생한 오류를 보고하기 위해 예외를 사용하면 CLR을 지원하는 프로그래밍 언어라면 예외처리를 통해 오류가 발생했다는 사실을 알 수 있음
    - 공용 언어 런타임이 개발자에게 스레드 프로그래밍 기능을 제공하므로 공용 언어 런타임을 지원하는 어떤 프로그래밍 언어에서든지 스레드를 만들 수 있음
    - 그러나 실행 시점에 CLR은 개발자가 소스코드를 작성할 떄 어떤 프로그래밍 언어를 사용하였는지 알 수 있는 방법은 없음
    - 가장 잘 표현 가능한 프로그래밍 언어를 택하여 사용하기만 하면 됨
    - 컴파일러가 CLR 환경에서 코드가 작동가능하도록 컴파일할 수 있기만 하면 코드를 어떤 프로그래밍 언어에서라도 개발 가능함
    
- 근데 선택한 프로그래밍 언어를 다른 프로그램이 언어와 함께 쓸 수 있다는 것이 왜 좋을까?

- 컴파일러: 프로그래밍 언어의 문법에 따라 코드의 옳고 그름을 판단해주는 도구
    - 소스 코드 검사, 확인, 의도를 표현하는 코드 만들 것
    - 서로 다른 프로그래밍 언어를 통해 다채로운 문법을 사용하여 개발하는 것이 의외로 개발자에게 큰 이점을 주기도 함

- ![](cap1.PNG)

- 소스 코드 파일은 다음과 같은 과정을 거쳐 컴파일이 됨

- CLR을 지원하는 프로그래밍 언어라면 원하는 대로 소스코드 작성이 가능함

- 해당 언어를 지원하는 컴파일러를 사용하여 문법을 점검하고 소스 코드를 분석하게 됨

- 어떤 컴파일러를 사용하든 최종적으로 **관리 모듈**을 결과물로 얻게 됨

- 관리 모듈을 32비트 Windows용 표준 이식 가능 파일 또는 64 비트 Windows용 표준 PE 파일로 실행하기 위해서는 CLR이 필요함

- 관리 어셈블리는 Windows 환경에서 항상 데이터 실행 방지(Data Execution Prevention, DEP)와 임의 기준 주소(Address Space Layout Randomization, ASLR) 기술의 이점 누릴 수 있음

- 이 두 기술을 통해 시스템 전반에 대한 보안 강화 가능함

- [관리 모듈 내의 각 영역]

    - | 영역                 | 설명                                                         |
        | -------------------- | ------------------------------------------------------------ |
        | PE32 또는 PE32+ 헤더 | 표준 Windows PE 파일 헤더이며 공용 객체 파일 형식 헤더와 유사함<br> 이 부분이 PE32타입을 사용하고 있다면 이 파일은 32비트 또는 64 비트 버전의 Windows에서 모두 실행 가능<br>이 부분이 PE32+ 형식을 사용한다면 이 파일을 실행하기 위해 64 비트 버전의 Windows가 필요함<br>이 헤더는 응용프로그램의 타입 구분 가능, GUI, CUI, DLL의 여부를 구분하고 언제 파일이 작성되었는지 시간 정보도 포함하고 있음<br>IL 코드만을 포함하는 모듈의 경우, PE32 및 PE32+ 헤더의 정보들은 무시됨. 네이티브 CPU 코드를 포함하는 모듈의 경우 네이티브 CPU 코드에 관한 정보가 헤더에 포함됨 |
        | CLR 헤더             | 이 모듈이 관리 모듈로 취급되기 위해서 필요한 정보(CLR과 유틸리티에 의해 해석된)들이 포함됨 이 헤더 안에는 필요로 하는 CLR의 버전과 몇 가지 플래그, 관리 모듈의 진입점 메서드(Main 메서드)의 MethodDef 메타데이터 토큰, 모듈 내의 메타데이터, 리소스, 강력한 이름, 그 외 기타 플래그와 정보들이 모듈 내의 어느 위치에 존재하는지, 각 블록 크기에 대한 정보가 포함됨 |
        | 메타데이터           | 관리 모듈에는 메타 데이터 테이블이 들어있음<br>테이블은 크게 두 종류가 있음<br>- 소스 코드 안에 들어있는 타입들과 멤버들의 선언을 서술하는 테이블<br>- 소스코드가 참조하는 타입들과 멤버들에 대해 서술하는 테이블 |
        | IL 코드              | 소스코드를 컴파일하여 만든 코드, 실행 시에 CLR은 IL 코드를 다시 네이티브 CPU 명령어로 컴파일하게 됨 |

        
## 공용 언어 런타임 로딩
- Windows가 EXE 파일의 헤더에 들어있는 정보에 따라 32비트 또는 64 비트 프로세스를 만들지 여부를 결정하면 Windows는 x86, x64, ARM 버전의 MSCORE.DLL 파일을 프로세스상의 주소 공간에 로드함
- X86이나 ARM 버전의 Windows에서는 32비트 버전의 MSCORE.DLL 파일이 %SYSTEMROOT%\SYSTEM32 디렉터리에서 찾을 수 있음
- X64 버전의 MSCORE.DLL 파일은 %SYSTEMROOT%\SYSTEM64 디렉터리에서 X64 버전의 MSCORE.DLL 파일은 %SYSTEMROOT%\SYSTEM32 디렉터리에서 찾을 수 있음
- 이런 매커니즘을 택하는 것은 이전 버전과의 호환성에 관련된 이유 때문임
- 그 다음, 프로세스의 주 스레드가 MSCORE.DLL 안에 정의된 메서드를 호출
- 이 메서드는 CLR을 초기화, EXE 어셈블리를 불러들이고, 어셈블리 안의 진입점(Entry Point) 메서드 호출을 시도함
- 이 시점에서 관리 응용프로그램이 실행됨

- 비관리 응용프로그램에서 Win32의 LoadLibrary 함수를 사용해서 관리 어셈블리를 로드하려고 하면 Windows는 이를 알아차리고 CLR이 로드되지 않은 경우 CLR을 로드해서 어셈블리 안에 들어있는 코드를 처리하기 위한 준비를 함
- 이 시나리오에서 프로세스는 이미 실행 중이고 이런 방식으로 사용하면 어셈블리의 활용성에 제한받게 됨

## 어셈블리 코드 실행하기
- 거의 모든 고급 언어들은 CLR이 제공하는 기능 중 일부만을 포장해서 제공해줌
- 그러나 IL 어셈블리 언어는 개발자들에게 CLR의 모든 기능들을 다룰 수 있게 해줌

- CLR이 어떤 기능을 제공하는지에 대해 알 수 있는 유일한 방법: CLR에 대한 명세서를 직접 읽는 것

- 메서드를 실행하기 위해 IL은 네이티브 CPU 명령어로 변환됨
- 이 작업이 CLR의 JIT(Just in time) 컴파일러에 의해 실행됨

- Main 메서드가 실행되기 바로 직전에 CLR은 Main 메서드 안에서 참조된 모든 타입들을 알아냄
- 이 과정에서 CLR이 내부적인 자료 구조를 하나 할당하도록 만듬
- 이것을 사용해서 참조된 타입에 대해 접근을 관리하는 용도로 사용하게 됨
- 각 Entry에는 각각의 메서드들에 대한 실제 코드가 메모리 주소상의 어느 위치에서 찾을 수 있는지 그 주소값을 보관함
- 이 자료구조를 초기화할 때, CLR은 각 항목들에 대해 문서화되지 않은 CLR 자신의 특정 함수를 가리키도록 설정하게 됨
- 여기서 우리는 이 함수를 JITCompiler라고 부르겠음

- 호출 발생 시, JITCompiler 함수는 어떤 메서드가 호출될 지, 어떤 타입에서 메서드가 정의되었는지를 알고 있음
- JITCompiler는 그 후 IL 코드 검사, 네이티브 CPU 명령어로 컴파일하는 과정 실행
- 네이티브 CPU 명령어는 메모리상에 동적할당된 메모리 블록에 저장함
- JITCompiler는 CLR에 의해 만들어진 타입 내부의 자료구조 안의 메서드 항목으로 돌아가서 방금 컴파일해서 네이티브 CPUㅁ ㅕㅇ령어를 저장한 메모리 블록 주소로 메모리 참조 주소를 바꿈 
- 마지막으로 JITCompiler는 해당 메모리 블록으로 점프해서 실제 코드를 수행함

- 성능 저하(Performance Hit)은 메서드가 최초로 호출될 때만 발생함
- 그 이후 발생하는 모든 후속 메소드 호출들은 네이티브 코드로서 빠른 속도로 실행됨
- 이유: 네이티브 코드에 대해서는 다시 내용을 검사하거나 컴파일할 필요 없기 때문임

- JIT 컴파일러는 네이티브 CPU 명령어를 동적 메모리상에 저장함
- 이 내용은 컴파일된 코드가 응용프로그램이 종료되는 시점에 자동 소거됨
- 만약 응용 프로그램을 나중에 다시 실행하거나 동시에 두 개 이상의 인스턴스를 실행하는 경우 JIT 컴파일러는 IL을 다시 네이티브 명령어로 캄파일하는 작업을 반복하게 됨
- 응용 프로그램에 따라서는 이런 방법으로 점유하는 메모리의 양을 읽기 전용의 코드 페이지를 실행 중인 프로그램 내의 모든 인스턴스에서 공유하는 네이티브 응용 프로그램보다 더 많이 사용하게 될 수도 있음

- 대부분의 응용프로그램들의 경우, JIT 과정에 발생하는 성능 저하는 크게 문제가 안 됨
- 이유: 대부분의 응용프로그램들은 같은 메소드를 반복적으로 사용하기 때문
- 이런 메서드들은 응용 프로그램이 실행되는 동안 단 한번 성능 저하를 일으킴

### IL과 검증 
- IL은 스택 기반의 언어임
- IL은 명령 종류에 무관함 
    - 더하기 명령어를 실행할 때, 스택에 들어있는 오퍼랜드의 종류를 확인하고 적절한 연산을 실행함
- IL의 가장 큰 장점: 응용 프로그램의 견고함과 보안을 이루게 해준다는 것
    - IL을 네이티브 CPU 명령어로 컴파일하는 동안, CLR은 **확인** 과정을 거치게 됨
    - 확인을 통해 높은 수준의 IL 코드를 검사, 모든 코드가 안전하게 작동할 수 있는지 점검함
- Windows에서는 각 프로세스가 고유의 가상 주소 공간을 가짐
    - 분리하는 이유: 응용 프로그램의 코드를 신뢰할 수 없기 때문임
    - Windows 프로세스들을 서로 분리된 주소 공간에 배치함 -> 견고함과 안정성을 얻을 수 있음, 어떤 프로세스가 역으로 다른 프로세스에 영향을 줄 수 없게 함
    - 관리 응용 프로그램을 Windows 단일 주소 공간 체계에서 여러 개를 실행하도록 할 수 있음

- Windows 상의 프로세스들은 기본적으로 많은 양의 시스템 자원들을 필요로 함
    - 성능에 영향을 끼칠 수 있고 사용 가능한 리소스에 제약을 받을 수 있음
- 관리 코드가 비관리 코드에 비해 가지는 장점: 하나의 OS 프로세스 내에서 여러 관리 응용프로그램을 실행 -> 프로세스의 숫자를 줄임
    - 적은 리소스 사용
    - 각자의 프로세스를 사용할 떄와 같은 견고함을 줌

- CLR이 이런 일들을 해줌   
    - 여러 관리 응용프로그램들을 단일 운영체제 시스템 프로세스 안에서 실행할 수 있는 기능 제공
- 각각의 응용 프로그램들은 앱도메인 안에서 실행됨
    - 기본적으로 각각의 관리 실행 파일들은 각자 분리된 주소에서 실행되고 하나의 앱도메인을 가짐

### 안전하지 않은 코드
- 기본적으로 마이크로소프트의 C# 컴파일러는 안전한 코드를 만들지만 개발자들이 안전하지 않은 코드를 작성하는 것도 허용함
- 안전하지 않은 코드를 이용해서 직접 메모리 주소 제어 가능, 특정 주소에 데이터를 쓸 수도 있음
- 이 기능은 매우 강력한 기능임, 비관리 코드와 상호 운용을 형성하거나 실행 속도에 민감한 알고리즘의 성능을 향상시킬 떄 매우 유용함

- 그러나 위험함...  
    - 데이터 구조를 훼손 가능
    - 시스템 공격 
    - 보안 취약점 만들 수 있음
- C# 컴파일러는 그래서... 안전하지 않은 코드를 포함하는 메서드 선언에 반드시 unsafe 키워드를 추가하도록 강제하고 있음

- MS는 PEVERIFY.EXE라는 유틸리티를 제공
    - 어셈블리 안의 메서드들이 안전하지 않은 코드들을 포함하는지 확인해줌
    - 이 도구로 참조하려는 어셈블리를 검사하는 것을 고려 가능
    - 이를 통해 응용프로그램이 인트라넷이나 인터넷상에서 실행하는데 문제가 있을 가능성을 미리 알려줌

- CLR의 확인 과정: 종속 관계에 있는 모든 메타데이터에 대한 접근을 필요로 함
- PEVERIFY 도구로 어셈블리를 검사할 때는 참조 가능한 모든 어셈블리를 찾아서 로드할 수 있도록 해줘야 함
- PEVERIFY 도구가 CLR을 통해 종속 관계에 있는 어셈블리들을 찾음 
- -> 어셈블리를 실행하기 위해 보통 사용하는 바인딩과 검색 규칙을 동일하게 사용함

## 네이티브 코드 생성 도구: NGEN.EXE
- NGEN.EXE 도구는 .NET Framework와 함께 제공되는 도구
    - IL 코드를 네이티브 코드로 컴파일하는 데 사용 가능
    - 응용 프로그램이 사용자의 컴퓨터에 설치되는 경우 사용 가능함
    - 설치 시점에서 코드가 컴파일되므로 CLR의 JIT 컴파일러가 실행 시점에서는 컴파일을 할 필요가 없음
    - -> 응용 프로그램의 성능을 높일 수 있음

- NGEN.EXE 도구가 가지는 시나리오 두 가지
    - 프로그램의 시작 시간을 개선:
        - NGEN.EXE를 사용하여 프로그램의 시작 시간을 개선 가능
        - IL 코드가 미리 네이티브 코드로 컴파일된 상태가 되므로 실행 시에 컴파일이 발생하지 않기 때문임
    - 응용 프로그램의 작업 집합(WorkingSet) 감소:
        - 어셈블리가 여러 프로세스에서 동시에 로드해서 사용한다면 NEGEN.EXE 도구를 이용하여 어셈블리를 미리 컴파일하여 응용 프로그램의 작업 집합의 크기를 줄일 수 있음.
        - NGEN.EXE 도구는 IL을 네이티브 코드로 컴파일해서 따로 분리된 파일로 저장하기 때문에 그러함
        - 이렇게 만들어진 파일은 여러 프로세스 주소상에서 파일이 메모리 매핑된 상태로 공유될 수 있음
        - 모든 프로세스들이 각자의 코드 사본을 만들지 않도록 할 수 있음

- CLR이 어셈블리 파일을 불러올 때, CLR은 어셈블리와 짝이 맞는 NGEN.EXE 에 의해 컴파일된 어셈블리를 찾게 됨
- 만약 컴파일된 어셈블리가 없다면 CLR은 IL 코드를 컴파일하기 위해 평소처럼 JIT 컴파일을 하게 될 것
- 그러나 적절한 어셈블리가 발견되면, CLR은 컴파일된 어셈블리 안의 네이티브 코드를 사용하게 됨, 실행 중에 컴파이링 다시 발생하지 않게 됨

- 그러나..... 실제로는 그렇게 이상적으로 작동하지 않음
- NGEN.EXE 파일로 만들어진 파일들이 가질 수 있는 잠재적인 문제점들
    - **지적 재산권 보호 기능 없음:**
        - CLR은 실행 시에 Refelction이나 Serialization 등의 기능이 작동하게 하기 위해 어셈블리에 대한 메타데이터에 접근해야 함
        - 메타데이터와 IL 코드가 같이 포함된 어셈블리가 꼭 필요함
        - 호출할 이유로 인해 NGEN.EXE 가 만든 네이티브 이미지를 사용할 수 없는 상황이 되면 언제든 JIT 컴파일로 방법 바꿀 수 있음 -> 원본 어셈블리 반드시 필요

    - **네이티브 이미지의 버전이 맞지 않을 가능성:**
        - CLR이 NGEN.EXE에 의해 처리된 이미지를 로드할 때는 컴파일된 코드와 현재 실행 환경의 몇 가지 주요 특징을 비교하게 됨
        - 만약 특징이 하나라도 다르다면 가져온 네이티브 이미지는 사용 불가능, 보통의 JIT 컴파일러 프로세스로 되돌아가게 됨

    - **열등한 실행 시간 성능:**
        - NGEN.EXE를 통해 코드를 컴파일하는 경우, JIT 컴파일러가 해낼 수 있는 것보다 추정 가능한 것이 적음
        - 이렇게 만들어진 코드는 NGEN.EXE가 만드는 코드가 열등한 것

- 서버 응용프로그램들은 이 방면으로 보는 이득이 없음
- 클라이언트 응용프로그램들은 NGEN.EXE를 통해 시작 시간을 개선하거나 작업 집합 감소시켜서 여러 프로그램이 동시에 같은 어셈블리를 사용하는 경우, 이득을 줄 수 있음

## 프레임워크 클래스 라이브러리
- .NET Framework는 **프레임워크 클래스 라이브러리**(Framework Class Library, FCL) 를 포함함

- FCL은 DLL 어셈블리들의 집합, 다양한 기능들을 제공하는 몇 천 가지 이상의 타입들로 구성됨

- FCL이 수천 가지의 타입들로 구성되므로 연관성이 있는 타입들은 개발자들에게 하나의 네임스페이스로 묶어서 제공함

- System 네임 스페이스의 경우, Object 기본 타입을 포함함, 이 클래스는 .NET Framework의 모든 클래스들의 부모 타입이 됨

- System 네임 스페이스에는 정수, 문자, 문자열, 예외 처리, 콘솔 입출력 등 기능적인 부분들을 포함하여 데이터 타입 간에 안전하게 타입 변환을 할 수 있도록 지원해주거나 데이터의 서식을 구성하거나 임의의 숫자를 만들거나 다양한 수학적 연산을 처리하는 유틸리티 타입들도 들어 있음

- System 이런 애들을 OOP 적으로 상속받고 확장하고 개발자들이 잘 사용 가능함

- [몇몇 일반적인 FCL 네임스페이스]

  | 네임스페이스                   | 들어있는 내용                                                |
  | ------------------------------ | ------------------------------------------------------------ |
  | System                         | 모든 응용 프로그램들을 위한 기본 타입들이 모두 들어있음      |
  | System.Data                    | DB와 통신하거나 데이터를 처리하기 위해 필요한 타입들이 들어있음 |
  | System.IO                      | 스트림 입출력, 디렉터리와 파일 탐색을 위해 필요한 타입들이 들어있음 |
  | System.Net                     | 낮은 수준의 네트워크 통신 지원, 일반적인 인터넷 프로토콜들을 쉽게 다룰 수 있도록 해줌 |
  | System.Runtime.InteropServices | 관리 코드와 OS 플랫폼이 제공하는 COM이나 Win32 API 또는 임의의 DLL 모듈과 상호작용 가능한 기능에 관련된 타입을 제공함 |
  | System.Security                | 데이터와 리소스를 보호하는 것에 관련된 타입들 제공           |
  | System.Text                    | ASCII나 유니코드 같은 다른 종류의 인코딩을 다루는 데 필요한 타입들을 제공함 |
  | System.Threading               | 비동기 작업이나 리소스 접근 동기화와 같은 기능을 제공하는 타입들을 제공함 |
  | System.Xml                     | XML 스키마와 데이터를 처리하는 데 필요한 타입들을 제공함     |

## 공용 타입 시스템
- CLR은 타입이라는 개념으로 가득 채워져 있음
- 타입은 응용프로그램과 다른 타입들에 기능들을 제공함
- 타입: 한 프로그래밍 언어로 작성된 코드가 다른 프로그래밍 언어로 작성된 코드들과 소통하는 매커니즘
    - CLR에서 가장 상위에 존재하는 개념
    - MS는 이것을 공용 타입 시스템(Common Type System, CTS)이라는 표준으로 정의

- CTS 사양에서는 하나의 타입 안에 멤버 정의하지 않을 수도, 하나 이상 정의 가능함
    - **필드**:
        - 객체의 상태를 정의하는 데이터 변수
        - 이름과 타입으로 구분됨
    - **메소드**:
        - 객체에 대해 작업을 하는 함수
        - 객체의 상태를 변경하는 목적으로 주로 사용됨
        - 이름, 원형, 한정자로 구성됨
        - 메서드 원형은 매개변수의 숫자와 그 순서, 각 매개변수의 타입들, 메서드가 반환하는 내용이 있는지의 여부, 반환하는 내용의 타입으로 구성됨
    - **속성**:
        - 호출하는 쪽에서는 마치 필드처럼 보임
        - 속성(Property) 를 구현하는 쪽에서 보면 한 개 또는 두 개의 메서드로 구성됨
        - 구현하는 쪽에서 입력 매개변수나 객체의 상태 점검할 수 있게 해줌, 필요 시 값 계산하도록 해줌
        - 사용자들이 간소화된 문법을 사용가능하도록 도움을 줌
        - 최종적으로 속성은 읽기 전용이거나 쓰기 전용으로만 작동하는 필드를 구현할 수 있게 해줌
    - **이벤트**:
        - 어떤 객체와 연관 짓고자 하는 다른 객체 사이의 통지 매커니즘이 작동할 수 있게 해줌

- CTS는 타입의 가시성과 타입이 노출하는 멤버에 대한 접근 제어 가능
- 공용 타입 시스템을 타입에 대해 가시성 경계를 형성하여 접근 가능 여부를 설정하는 규칙 만들고 관리 가능하게 하며, CLR은 이 규칙을 엄격하게 준수함

- 호출자에 드러나는 타입의 경우, 세부적으로 타입의 멤버들에 대한 가시성 설정을 적용 가능
- 멤버에 대해 적용 가능한 한정자들의 유형
    - *Private*:
    - *Family*:
    - *Family and Assembly*:
        - 현재 멤버가 선언된 클래스를 상속받은 자식 클래스에 대해 접근 가능
        - 근데 그 클래스가 같은 어셈블리 안에 들어가는 클래스여야 함
    - *Assembly*:
        - 같은 어셈블리 안에 포함된 코디이면 자유롭게 접근 가능
        - 많은 프로그래밍 언어들이 이것을 `internal`이라고 표현함
    - *Family or assembly*: 
        - 앞의 Family 한정자와 같이 어셈블리 아니안 밖의 구분 없이 상속 관계에 있으면 자유롭게 접근 가능하다는 것은 동일함
        - 같은 어셈블리 안에 있는 코드는 상속 관계 밖이라도 이 한정자로 선언된 멤버에 접근 가능
    - *Public*: 이 멤버는 클래스 상속 관계 여부나 어셈블리 위치에 무관하게 접근 가능
- 모든 타입들은 미리 정의된 타입인 System.Object 타입으로부터 상속받아야만 함
- Object 타입은 System 네임스페이스 아래에 들어있는 타입의 이름임
- 이 Object 타입은 다른 모든 타입들의 최상위 부모, 모든 타입 인스턴스들은 최소한의 공통 기능을 가지게 됨

- System.Object 타입을 통해 할 수 있는 일들
    - 두 인스턴스의 동일함 판정
    - 인스턴스의 유일함을 보증하는 해시 값을 가져옴
    - 인스턴스의 실제 타입을 조회함
    - 인스턴스의 부분 복제 처리
    - 인스턴스 객체의 현재 상태를 설명하는 문자열 표현을 가져옴

## 공용 언어 사양
- CLS는 모든 언어들이 호환성을 위해 지켜야 할 최소한의 기능 집합을 제공함
- ![](pic1.PNG)
- 특정 프로그래밍 언어 안에서 타입 설계하고 다른 언어들이 만들어진 타입을 사용하고 싶다면 CLS 밖의 기능이 제공하는 이점을 Public 이나 Protected 멤버에서는 사용 불가능
- 이것을 어긴다면 다른 프로그래밍 언어를 사용하는 개발자들은 사용할 수 없는 타입이 됨

- [C#으로 CLS 호환 타입을 작성하려고 시도한 예제]
- 그러나 아래 타입은 몇 가지 CLS를 준수하지 않는 부분이 있음, C# 컴파일러는 이런 부분들에 대해 문제점을 알리게 됨
```C#
using System;

//컴파일러로 CLS 호환 여부를 점검하도록 지시함
[assembly: CLSCompliant(true)]

namespace SomeLibrary {
    // Public 한정자를 사용하여 클래스가 드러나므로 문제가 있을 경우 경고가 표시됨

    public sealed class SomeLibraryType{

        //경고: 'SomeLibrary.SomeLibraryType.Abc() ' 메서드의 반환 타입이 CLS를 준수하지 않음
        public UInt32 Abc() { return 0; }
        //경고: 'SomeLibrary.SomeLibraryType.abc() ' 메서드의 식별자가 대소문자를 다르게 쓴 것 이상의 차이점은 없음
        public void abc() { }
        //이상 없음: 클래스 내부에서만 사용되므로 문제 없음
        private UInt32 ABC() { return 0; }
    }
}
```

- CLS의 규칙에 대해 알아보자~
    - CLR에서는 모든 멤버들이 필드 or 메서드임
    - 각각의 프로그래밍 언어들이 필드에 접근하거나 메서드를 호출하는 기능이 있어야 함
    - 어떤 필드와 메서드들은 특별한 방법으로도 or 일반적인 방법으로도 사용됨
    - 프로그래밍을 단순화하기 위해 이런 공용 프로그래밍 패턴을 쉽게 다룰 수 있도록 추상화된 개념을 제공하기도 함
    - ex) 열거타입(Enum), 배열, 속성, 인덱서, 델리게이트, 이벤트, 생성자, 소멸자, 연산자 오버로드, 변환 연산자 등이 있음
- 컴파일러가 이런 개념을 사용하는 코드를 파악하면 이런 내용들을 CLR과 다른 모든 프로그래밍 언어에서 접근 가능하도록 필드와 메서드의 형태로 풀어내야 함

## 비관리 코드와의 상호 운용성
- CLR은 다음 세 가지 상호 운용 시나리오들을 지원함
- **관리 코드는 DLL 안의 비관리 함수 호출 가능:**
    - 관리 코드는 플랫폼 호출(Platform Invoke, P/Invoke)를 통해 쉽게 DLL 안에 들어있는 함수들을 호출 가능함
    - 그래서 FCL 안의 많은 타입들이 내부적으로 KERNEL32.DLL이나 USER32.DLL 등의 DLL이 노출하는 함수들의 기능을 활용함
    - 많은 프로그래밍 언어들이 DLL 안에 들어있는 함수들을 호출하기 위해 손쉽게 사용 가능한 매커니즘 사용함
- **관리 코드는 기존의 COM 컴포넌트(서버) 사용 가능:**
    - *COM*: 어떤 프로그램이나 시스템을 이루는 컴포넌트들이 상호 통신가능하도록 하는 매커니즘
    - 이들 컴포넌트들의 타입 라이브러리를 사용하여 이 COM 컴포넌트들을 설명하는 관리 어셈블리를 만들어낼 수 있음
    - 관리 코드는 만들어진 관리 어셈블리 안에서 다른 통상적인 관리 타입들과 마찬가지로 접근해서 기능 사용 가능함
    - .NET Framework SDK와 함께 제공되는 TLBIMP.EXE 도구에 대한 설명을 확인하여 더 자세한 정보 얻을 수 있음
- **비관리 코드가 관리 타입을 서버로 사용 가능:**
    - 비관리 코드들 안에서 개발자의 코드가 정상적으로 작동하게 하려면 COM 컴포넌트를 만들어야 함
    - 관리 코드를 사용하면 이런 컴포넌트를 만드는 작업이 훨씬 간소해지고 참조횟수나 이터페이스에 관한 고민 업시 쉽게 사용 작업 가능
    - 예를 들어, C#을 이용하여 ActiveX 컨트롤을 만들건자 셸 확장을 만들 수 있음