# Chapter03. 공유 어셈블리와 강력한 이름의 어셈블리🐻

## 1. 두 가지 어셈블리, 두 가지 배포 방법
- CLR은 약한 이름의 어셈블리, 강력한 이름의 어셈블리를 지원함
- 두 어셈블리는 구조적으로 동일함
- 차이점: 
    - 강력한 이름의 어셈블리는 게시자의 공개키, 개인 키 한 쌍을 이용 -> 어셈블리 게시자 식별 가능하도록 서명함
    - 이 키쌍을 통해 어셈블리가 고유하게 식별되고 안저하게 유지되고 버전관리를 할 수 있음, 어셈블리가 컴퓨터 어디든 자유롭게 배포될 수 있도록 해줌
    - 어셈블리를 고유하게 식별할 수 있게 해주는 기능: CLR이 안전하다고 알려진 일부 정책들을 응용프로그램이 강력한 이름의 어셈블리에 바인딩 시 강제로 적용될 수 있게 해줌
- 어셈블리는 두 가지 형태로 배포될 수 있음
    - 개별적으로 배포되는 어셈블리: 응용프로그램의 기본 디렉터리나 그 아래의 디렉터리에 배포되는 것    
    - 전역으로 배포되는 어셈블리: 잘 알려진 위치에 배포됨 -> CLR이 어셈블리를 쉽게 찾을 수 있게 함
    
      | 어셈블리 종류        | 개별적으로 배포 가능 여부 | 전역으로 배포 가능 여부 |
      | -------------------- | ------------------------- | ----------------------- |
      | 약한 이름의 어셈블리 | Y                         | N                       |
      | 강한 이름의 어셈블리 | Y                         | Y                       |
    
## 2. 어셈블리를 강력한 이름으로 서명하기
- 여러 응용프로그램에서 하나의 어셈블리를 이용하는 경우, 어셈블리는 잘 알려진 디렉터리에 반드시 설치되어야 함
- CLR은 이런 어셈블리를 실행 중에 찾을 경우 이 디렉터리에서 찾을 수 있어야 함

- 문제가 있는데...
- 같은 파일 이름을 가진 어셈블리를 서로 다른 곳에 만들어 배포해야 할 수 있음

- 잘 알려진 디렉터리에 복사된 경우, 나중 복사된 어셈블리가 기존 어셈블리를 덮어씀 -> 이전 버전의 어셈블리 참조하던 모든 응용 프로그램들이 사용하던 함수 못 찾게 됨
- -> DLL 지옥의 원형

- 파일 이름을 이용 => 어셈블리를 구분하는 것은 불충분
- 고유하게 식별 가능한 새로운 매커니즘이 필요했음 -> 이 매커니즘 = 강력한 이름의 어셈블리
- 확장명 없는 파일 이름, 버전 번호, 문화권 정보, 공개 키 값 -> 어셈블리를 고유하게 식별

- 강력한 이름의 어셈블리 만들기 위한 첫 작업: .NET Framework SDK와 Visual Studio와 함께 제공되는 강력한 이름 SN.EXE
    - 지정하는 명령 줄 스위치 선택에 따라 종류 다양 -> 여러 기능 이용 가능
    - SN.EXE 유틸리티의 모든 명령 줄 스위치들은 대소문자 구분에 민감함
    - 공개 키/비밀 키 쌍을 생성하려면 다음과 같이 SN.EXE 유틸리티를 실행해야 함
    - `SN -k MyCompany.snk`

- 공개 키 숫자들의 값은 매우 큼
- 그래서 불편... -> 개발자들&사용자들의 편의를 위해 공개 키 토큰을 만듬
- 공개키 토큰: 64비트 해시 값

- 파일 서명의 의미: 
    - 강력한 이름의 어셈블리 생성 시, 어셈블리의 FileDef 매니페스트 메타테이블에 어슴블리를 구성하는 모든 파일들의 내역이 포함됨
    - 각 파일의 이름이 매니페스트에 추가됨, 파일의 내용이 해시 갑승로 계산 -> FileDef 테이블에 파일 이름마다 해시 값이 저장됨
    - 해시 값 계산 알고리즘의 선택: AL.EXE 유틸리티의  /algid 스위치 or 어셈블리 수준에서 System.Reflection.AssemblyAlgorithimIDAttribute 사용자 정의 특성을 어셈블리의 소스 코드 파일상에 넣어 지정 가능(기본 설정: SHA-1 알고리즘)

    - 매니페스트 포함한 PE 파일 만들어지면 PE 파일 내용 중 Authenticode 서명, 어셈블리의 강력한 이름 데이터, PE 헤더 체크섬을 제외한 모든 내용들이 해시 값으로 계산
    - 게시자의 비밀 키로 해시값이 서명됨 -> RSA 디지털 서명으로 해시에 포함되지 않은 PE 파일상의 예약된 공간에 저장됨
    - PE 파일의 CLR 헤더는 디지털 서명이 파일의 어느 위치에 기록되어 있는지를 가리키도록 수정됨

- 전체 공개키는 파일이 변조되지 않았는지 확인하는 과정에서 필요함
- 결론: 공개 키가 있으면 강력한 이름의 어셈블리, 아니라면 약한 이름의 어셈블리

## 전역 어셈블리 캐시
- 많은 응용 프로그램에 의해 어떤 어셈블리가 사용된다면, 이 어셈블리는 반드시 잘 알려진 디렉터리에 들어가야 함
- 이 잘 알려진 위치 = 전역 어셈블리 캐시(Global Assembly Cache, GAC)
- 보통 이 디렉터리가 GAC의 위치임
`%SYSTEMROOT%\Microsoft.NET\Assembly`

- GAC 디렉터리 밑에는 수많은 하위 디렉터리 있음, 하위 디렉터리들의 이름 짓기 위한 알고리즘도 있음
- 이 폴더 밑으로 파일 임의로 복사하여 집어넣는 것은 하면 안 됨
- 대신 지정된 도구 사용 -> GAC 에 새로운 어셈블리 추가 가능(이 도구들이 모든 걸 알고 있음)
- GAC 안에 약한 이름의 어셈블리 절대 추가 불가능
- 개발과 테스트 도중 강력한 이름의 어셈블리를 GAC 안에 설치할 수 있는 보편적인 도구: GACUTIL.EXE

- GAC에 어셈블리를 '등록'하는 이유?
    - 나중에 설치된 파일이 기존의 파일을 덮어쓰게 되서 프로그램을 망가뜨리는 것 방지
    - 서로 겹치지 않게 분리된 하위 디렉터리로 두 어셈블리가 복사됨

## 강력한 이름의 어셈블리를 참조하는 어셈블리 만들기
- 어셈블리 만들 때, 만들어지는 어셈블리는 강력한 이름의 어셈블리를 하나 이상 참조함
- MSCORLIB.DLL안의 System.Object 타입울 참조하게 되므로, 이 아이가 강력한 어셈블리이기 때문임
- 파일 이름이 전체 경로로 지정되어 있다면, CSC.EXE에서는 지정된 파일을 로드 -> 그 안에 들어있는 메타데이터 정보를 사용 -> 어셈블리를 빌드
- 경로 없이 파일 이름만 지정하면 다음의 순서에 따라 CSC.EXE가 어셈블리를 찾기 위해 경로탐색을 함
    - 작업 중인 디렉터리
    - CSC.EXE 파일과 CLR의 DLL들이 포함되어 있는 디렉터리
    - /lib 컴파일러 스위치를 통해 지정된 모든 디렉터리들
    - LIB 환경 변수에 지정된 모든 디렉터리들

- .NET 프레임워크 설치 시, MS의 어셈블리들은 실제로 두 곳에 복사되어 설치됨
- 컴파일러와 CLR 디렉터리에 파일 복사됨 -> 어셈블리를 쉽게 빌드할 수 있게 도움을 줌 -> GAC에 설치되어 실행 시 어셈블리 파일을 찾을 수 있게 도움을 줌

## 강력한 이름의 어셈블리로 코드 위조 방지하기
- 비밀 키를 이용 -> 어셈블리 서명, 어셈블리 안에 공개 키와 서명 추가 -> CLR이 어셈블리가 최초로 만들어진 이후로 훼손되거나 수정되지 않았음을 판별 가능
- 어셈블리가 GAC에 설치될 떄, 시스템은 매니페스트를 포함하는 파일의 내용을 해시 값으로 계산 -> PE 파일 안에 들어있는 RSA 디지털 서명값의 해시값을 비교
    - 같은 값이라면, 파일 내용이 외부에서 훼손 안 된 것으로 인식
- 시스템은 어셈블리의 다른 파일들의 내용을 해시 값으로 계산 -> 매니페스트 파일의 FileDef 테이블에 들어있는 해시 값들과 대조
    - 하나라도 일치 안 하면 어셈블리의 파일 중 하나 이상이 변조된 것으로 보고 GAC에 설치 안 함
- 파일의 해시 값은 응용 프로그램이 매번 실행되고 어셈블리를 로드하는 시점마다 계산되는 것
    - 이 문제는 어셈블리 파일이 훼손되거나 손상되었는지 확인하고 보증하는 일을 하기 위한 비용임
    - CLR이 실행 중에 해시 값이 일치하지 않음을 발견 시, System.IO.FileLoadException 예외 발생

## 서명 연기
- 비밀 키에 대한 접근 권한 통제가 귀찮은 일이므로, .NET Framework에서는 **서명 연기** 라는 개념 제공
    - =**부분 서명**이라고도 함
    - 조직에서 사용하는 공개 키만 사용, 어셈블리 만들 수 있게 하고 비밀 키를 요구하지 않음
    - 공개 키 사용 -> 서명 연기로 만들어진 어셈블리 참조하는 다른 어셈블리의 AssemblyRef 메타데이터 항목 안에 올바른 공개 키 값을 넣을 수 있게 해줌
    - GAC 안에도 정상적으로 설치되게 함
- 이하 생략... 

## 강력한 이름의 어셈블리를 개별적으로 배포하기
- 개별적으로 배포하면 다른 응용프로그램과 어셈블리 사이를 완전히 격리 가능 -> 더 단순한 설치와 배포 방법을 추구하는 경우 목적에 부합함
- GAC 또는 개별적으로 배포하는 방법, 지정된 응용프로그램들이 이해하는 독자적인 디렉터리 구조 형성해서 배포하는 방법이 있음
- ex) 세 개의 응용프로그램을 배포하면서 강력한 이름의 어셈블리를 이 응용프로그램에서 공유하게 하면?
    - 설치하면서 네 개의 디렉터리 만들 수 있음
    - 세 개의 응용프로그램을 각각 담을 디렉터리 + 이 응용프로그램들이 공유할 디렉터리
    - 별로 추천하는 방법은 아님

## 실행 중에 타입에 대한 참조를 어떻게 찾아내는가?
- 이런 소스코드가 있다고 하자(2장에서 봄)
```C#
public sealed class Program
{
    public static void Main()
    {
        Sytem.Console.WriteLine("Hi");
    }
}
```
- 이 코드는 컴파일 됨 -> PROGRAM.EXE라는 어셈블리로 만들어짐
- 이 응용프로그램 실행 -> CLR 로드됨 -> 초기화됨
- -> CLR은 어셈블리의 CLR 헤더 읽음 -> MethodDef 메타데이터 테이블에서는 파일 내에 들어있는 메서드의 IL 코드의 오프셋 확인 
- -> 위치 알아냄 -> JIT 컴파일 과정 거쳐서 실행하려는 코드가 정확한지, 타입 안정성 준수하는지 파악
- 네이티브 코드가 그 다음 실행 시작

- ILDSAM.EXE 실행해서 얻은 IL 코드를 JIT 컴파일러 통해 컴파일 -> CLR은 이 코드에서 참조하는 모든 타입, 멤버들에 대해 파악
- 이것을 정의하는 어셈블리들을 로드하게 됨

- 참조된 타입을 찾아낼 때, CLR은 다음 세 위치 중 한 곳에서 타입을 찾아냄
    - **같은 파일**: 같은 파일 안에 들어있는 타입에 대한 액세스는 컴파일 시점에 파악 완료됨, "초기 바인딩"이라고 이야기하기도 함. 파일에서 직접 타이 로드, 실행 계속함
    - **다른 파일, 같은 어셈블리**: 
        - 실행 시점에서 차즌 타입이 어셈블리 대표 매니페스트 상의 ModuleRef 테이블에 서술된 파일 안에 찾는 내용이 들어있을 거라는 전제 아래서 출발
        - CLR은 어셈블리의 매니페스트 파일이 로드된 디렉터리를 검색해서 파일 찾으면 파일이 무결성 검증 위해서 해시 값 확인, 타입 발견되면 해당 타입을 로드해서 실행 계속함
    - **다른 파일, 다른 어셈블리**:
        - 참조하는 타입이 다른 어셈블리의 파일에 있는 경우, 실행시점에 참조되는 어셈블리의 매니페스트를 로드하게 됨
        - 매니페스트 안에서 해당 타입 못 찾으면, 매니페스트와 연결된 실제 파일 찾아서 다시 로드하게 됨
        - 정확한 타입 찾으면 해당 타입을 로드해서 실행 계속함
        - 만약 못 찾으면 상황에 맞게 대응되는 적절한 에외 발생 -> 문제점 알림

    - CLR의 경우, 모든 어셈블리를 이름, 버전, 문화권, 공개 키로 식별
    - 그러나 GAC의 경우, 어셈블리 식별을 위해 이름, 버전, 문화권, 공개 키 이외에 CPU 아키텍처 정보를 하나 더 필요로 함
    - GAC 안에서 어셈블리 찾기 위해서라면 CLR은 어떤 프로세서 아키텍처 위에서 실행되는 응용프로그램을 구동 중인지 확인해야 함

## 고급 관리 기능 제어와 설정
- 어떻게 하면 참조된 어셈블리의 파일들을 응용프로그램의 기본 디렉터리 아래의 서브 디렉터리로 이동시킬 수 있는가?
- 응용프로그램의 XML 설정 파일을 어떻게 변경해야 CLR이 옮긴 파일의 위치를 찾을 수 있는가?
- 이 두 가지에 대해 살펴볼 것

```xml
<?xml version="1.0"?>
<configuration>
    <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.vl">
            <probing privatePath="AuxFiles;bin\subdir" />
            <dependentAssembly>

                <assemblyIdentity name="SomeClassLibrary"
                    publicKeyToken="32ab3ba4e0a" culture="neutral"/>

                <bindingRedirect
                    oldVersion="1.0.0.0" newVersion="2.0.0.0"/>

                <codeBase version="2.0.0.0"
                    href="http://www.Wintellect.com/SomeClassLibrary.dll" />

            </dependentAssembly>

            <dependentAssembly>

                <assemblyIdentity name="TypeLib"
                    publicKeyToken="lf2e74e897abbcfe" cultre=neutral/>
                <bindingRedirect 
                    oldVersion="3.0.0.0-3.5.0.0" newVersion="4.0.0.0"/>

                <publisherPolicy apply="no"/>
            </dependentAssembly>
    </runtime>
</configuration>
```
- **Probing 요소**:
    - 약한 이름의 어셈블리 로드 시 응용 프로그램의 기본 디렉터리 아래에 있는 AuxFile 디렉터리와 bin\subdir 디렉터리를 찾도록 지시하는 역할을 함
    - 강력한 이름의 어셈블리를 찾을 때는 GAC 또는 codeBase 요소에 지정된 URL을 기준으로 검색하게 됨
        - 여기서 못 찾으면 응용프로그램의 개별 디렉터리에서 추가로 검색 수행
- **첫번째 dependentAssembly, assemblyIdentity, bindingRedirect 요소**:
    - 공개 키 토큰 32ab3ba4e0a를 관리하는 조직에서 게시한 SomeClassLibrary 어셈블리의 버전 1.0.0.0을 버전 2.0.0.0으로 찾도록 지시함
- **codeBase 요소**:
    - SomeClassLibrary라는 어셈블리의 버전 2.0.0.0을 찾으려고 할 떄 `http://www.Wintellect.com/SomeClassLibrary.dll`에서 어셈블리 찾도록 지시하게 됨
    - 약한 이름의 어셈블리에서도 동작
        - 어셈블리의 버전 번호가 무시됨, XML의 codeBase 요소에서도 버전 번호가 생략되어야 함
        - codeBase에 기재되는 로컬 디렉터리의 URL은 반드시 응요프로그램의 기본 디렉터리 아래에 있는 상대경로여야 함
- **두 번쨰 반복되는 dependentAssembly, assemblyIdentity, bindingRedirect 요소**:
    - 공개키 토큰 lf2e74e897abbcfe를 관리하는 게시자에서 게시한 문화권 중립의 TypeLib 어셈블리 버전 대역 3.0.0.0-3.5.0.0 중 일치하는 어셈블리 대신 4.0.0.0 버전의 어셈블리 찾도록 지시함
- **publisherPolicy 요소**:
    - TypeLib 어셈블리 배포 시 해당 어셈블리와 연결된 게시자 정책 파일을 같이 배포한 경우, CLR은 현재 파일의 설정을 무시하게 됨
### 게시자 정책 제어
- 어떻게 하면 어셈블리의 게시자가 직접 이런 정책을 만들 수 있는지 살펴볼 것
- 어셈블리를 방금 만들어서 사용자들에게 배포하기 위해 패키지로 만들어야 한다고 생각하자
```xml
<configuration>
    <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.vl">
            <dependentAssembly>

                <assemblyIdentity name="SomeClassLibrary"
                    publicKeyToken="32ab4ba5e0a69a1" culture="neutral"/>

                <bindingRedirect 
                    oldVersion="1.0.0.0" newVersion="2.0.0.0"/>

                <codeBase version="2.0.0.0"
                    href="http://www.Wintellect.com/SomeClassLibrary./dll"/>
            </dependentAssembly>
        </assemblyBinding>
    </runtime>
</configuration>
```
- 게사자가 게시자 정책 어셈블리를 배포하려고 할 때, 새 어셈블리는 고친 것보다 더 많은 문제를 야기할 가능성 있음
- 이런 일이 있을 때, 관리자는 CLR이 게시자 젗액 어셈블리를 무시하도록 구성하기를 원할 수 있음
- 실행 시점에 이를 결정하도록 하기 위해 관리자는 응용프로그램의 설정 파일 편집해서 다음의 요소 추가하도록 할 수 있음
`<publisherPolicy apply="no"/>`
- 이 요소는 응용 프로그램의 설정 파일 내의 assemblyBinding 요소 아래에 들어갈 수 있고 이를 통해 모든 어셈블리에 적용 가능함
- 특정 어셈블리에 대해서만 적용하는 것도 가능
- CLR이 응용프로그램의 파일을 로드해서 치리 시, GAC에 설치된 게시자 정책 어셈블리를 사용하지 않도록 동작 바뀜
- 대신에 이전 버전의 어셈블리를 계속 사용하게 될 것임
- 이런 설정이 Machine.config 파일에 지정되어있지 않는 한 Machine.config 파일의 설정은 계속 사용하게 됨