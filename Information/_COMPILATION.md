##### Seven COMPILATION.md

>The Seven project should build when targeted for .Net Framework +4.5.
>If it does not compile directly after downloading it, please notify
>the development team (see "SUPPORT.md"). The compilation of the Seven
>project can be altered with the following pre-processor directives:
>
> - "no_error_checking"
>
>This preprocessor directive will eliminate most exception handling in
>the Seven project. This can speed up low-level operations such as vector
>additions. However, this directive should be avoided unless on the final 
>release of a speed-critical software.
>
> - "unsafe_code"
>
>This preprocessor directive will use the unsafe code regions instead of
>the safe code regions. This directive should be used during normal
>compilations of the Seven project(s), because it will potentially provide
>noticeable speed improvements.
>
> - "show_Numeric"
>
>This preprocessor directive is primarily for development purposes to test
>the mathematics code that will compile at runtime. It should not be used
>outside of development of the SevenFramework.